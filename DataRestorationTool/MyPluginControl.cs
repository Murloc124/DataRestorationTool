﻿using DataRestorationTool.Model;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace DataRestorationTool
{
    public partial class MyPluginControl : PluginControlBase
    {
        #region Private Properties
        private List<EntityMetadata> tableMetaDataList;
        #endregion

        #region Public Proprties

        #endregion

        public MyPluginControl()
        {
            InitializeComponent();
            dateTime_From.Value = DateTime.Now.AddMonths(-1);
            dateTime_To.Value = DateTime.Now;
        }


        #region Event Handling
        private void MyPluginControl_Load(object sender, EventArgs e)
        {
        }

        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            LoadTableData();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsb_LoadAudit_Click(object sender, EventArgs e)
        {
            if (combo_Tables.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a table from the list");
                return;
            }
            if (dateTime_From.Value > dateTime_To.Value)
            {
                MessageBox.Show("Please select a From Date earlier or equal to the To Date");
                return;
            }

            LoadAuditData((Tuple<int, string, string>)combo_Tables.SelectedItem, combo_Tables.SelectedValue);
            EnableControls(false);
            dataGrid_Details.DataSource = null;
        }

        private void tsb_RestoreData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restore these deleted records?", "Confirmation", MessageBoxButtons.YesNo).ToString().ToUpper() == "YES")
            {
                RestoreData();
            }
        }

        private void dataGrid_DeletedRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var auditItem = (AuditItem)dataGrid_DeletedRecords.Rows[e.RowIndex].DataBoundItem;
                ShowAuditDetails(auditItem);
            }
            else if (e.ColumnIndex == 0)
            {
                var checkBoxCell = (DataGridViewCheckBoxCell)dataGrid_DeletedRecords.Rows[e.RowIndex].Cells[0];
                checkBoxCell.Value = checkBoxCell.Value is null ? true : !(bool)checkBoxCell.Value;
                
                if ((bool)checkBoxCell.Value)
                {
                    tsb_RestoreData.Enabled = true;
                    return;
                }

                foreach(DataGridViewRow row in dataGrid_DeletedRecords.Rows)
                {
                    if (row.Cells[0].Value != null && (bool)row.Cells[0].Value)
                    {
                        tsb_RestoreData.Enabled = true;
                        return;
                    }
                }

                tsb_RestoreData.Enabled = false;
            }
        }
        #endregion

        #region Logic
        private void WhoAmI() => Service.Execute(new WhoAmIRequest());

        private void EnableControls(bool enabled = true)
        {
            combo_Tables.Enabled = enabled;
            dateTime_From.Enabled = enabled;
            dateTime_To.Enabled = enabled;
            tsb_LoadAudit.Enabled = enabled;
        }

        private void LoadTableData()
        {
            ExecuteMethod(WhoAmI);

            var dataResultTables = new List<Tuple<int, string, string>>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Tables with Auditing enabled..",
                Work = (w, ev) =>
                {
                    var metaDataResponse = (RetrieveAllEntitiesResponse)Service.Execute(new RetrieveAllEntitiesRequest { EntityFilters = EntityFilters.Attributes });
                    tableMetaDataList = new List<EntityMetadata>();

                    foreach (var tableMetaData in metaDataResponse.EntityMetadata)
                    {
                        if (tableMetaData.IsAuditEnabled.Value)
                        {
                            dataResultTables.Add(new Tuple<int, string, string>(tableMetaData.ObjectTypeCode.Value, tableMetaData.DisplayName.UserLocalizedLabel.Label, tableMetaData.PrimaryNameAttribute));
                            tableMetaDataList.Add(tableMetaData);
                        }
                    }

                    ev.Result = dataResultTables.OrderBy(_ => _.Item2).ToList();
                },
                PostWorkCallBack = ev =>
                {
                    combo_Tables.DataSource = ev.Result;
                    combo_Tables.DisplayMember = "Item2";
                    combo_Tables.ValueMember = "Item1";

                    EnableControls();
                },
                IsCancelable = false, AsyncArgument = null
            });
        }

        private void LoadAuditData(Tuple<int, string, string> selectedTable, object selectedTableValue)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Deleted Records..",
                Work = (w, ev) =>
                {
                    var result = new List<AuditItem>();
                    var queryResult = Service.RetrieveMultiple(BuildAuditQuery(selectedTableValue));

                    foreach (var item in queryResult.Entities)
                    {
                        var auditDetailResp = (RetrieveAuditDetailsResponse)Service.Execute(new RetrieveAuditDetailsRequest { AuditId = item.Id });

                        if (auditDetailResp.AuditDetail.GetType() != typeof(AttributeAuditDetail)) continue;

                        var auditDetail = auditDetailResp.AuditDetail as AttributeAuditDetail;

                        result.Add(new AuditItem
                        {
                            AuditId = item.Id,
                            AuditDetail = auditDetail,
                            DeletedBy = (item["userid"] as EntityReference).Name,
                            DeletionDate = (DateTime)item["createdon"],
                            Table = (item["objectid"] as EntityReference).LogicalName,
                            RecordId = (item["objectid"] as EntityReference).Id,
                            Metadata = tableMetaDataList.FirstOrDefault(_ => _.ObjectTypeCode == selectedTable.Item1),
                            Name = selectedTable.Item3 != null && auditDetail.OldValue.Contains(selectedTable.Item3) ? auditDetail.OldValue[selectedTable.Item3].ToString() : null,
                        });
                    }

                    ev.Result = result.OrderByDescending(_ => _.DeletionDate).ToList();
                },
                PostWorkCallBack = ev =>
                {
                    if (((List<AuditItem>)ev.Result).Count == 0)
                    {
                        MessageBox.Show($"No deleted records for table {selectedTable.Item2} during the selected period.");
                        dataGrid_DeletedRecords.DataSource = null;
                    }
                    else
                        dataGrid_DeletedRecords.DataSource = ev.Result;

                    EnableControls();
                },
                AsyncArgument = null,
                IsCancelable = true,
            });
        }

        private void ShowAuditDetails(AuditItem auditItem)
        {
            var result = new List<DeletedField>();

            foreach (var item in auditItem.AuditDetail.OldValue.Attributes)
            {
                var metaDataAttr = auditItem.Metadata.Attributes.Where(_ => _.SchemaName.ToLower() == item.Key.ToLower()).ToList();

                if (metaDataAttr.Count > 0)
                    result.Add(new DeletedField
                    {
                        FieldName = metaDataAttr[0].DisplayName.UserLocalizedLabel.Label,
                        Value = GetFormattedValue(item.Value),
                    });
            }

            dataGrid_Details.DataSource = result;
        }

        private object GetFormattedValue(object input)
        {
            switch (input.GetType().Name)
            {
                case "EntityReference":
                    return ((EntityReference)input).Name;
                case "OptionSetValue":
                    return ((OptionSetValue)input).Value;
                case "Money":
                    return ((Money)input).Value;
                case "OptionSetValueCollection":
                    var returnList = "";
                    foreach (var item in (OptionSetValueCollection)input)
                        returnList += $"{item.Value},";
                    return returnList.TrimEnd(',');
                default:
                    return input;

            }
        }

        private void RestoreData()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Restoring Deleted Data..",
                Work = (w, e) =>
                {
                    try
                    {
                        foreach(DataGridViewRow row in dataGrid_DeletedRecords.Rows)
                        {
                            var checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];
                            if (checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                            {
                                var entityToCreate = ((AuditItem)row.DataBoundItem).AuditDetail.OldValue;
                                entityToCreate.Attributes.Remove("statecode");
                                entityToCreate.Attributes.Remove("statuscode");
                                Service.Create(entityToCreate);
                            }
                        }
                        e.Result = true;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorDialog(ex, "Failed to Restore record(s)");
                        e.Result = false;
                    }
                },
                PostWorkCallBack = e =>
                {
                    if ((bool)e.Result != false)
                    {
                        MessageBox.Show("Record(s) restored succesfully!");
                    }
                }, IsCancelable = true
            });
        }
        #endregion

        #region QueryExpressions
        private QueryExpression BuildAuditQuery(object objectTypeCode)
        {
            var query = new QueryExpression("audit");
            query.ColumnSet = new ColumnSet("auditid", "regardingobjectid", "createdon", "userid", "objectid", "objecttypecode", "action");
            query.Criteria.Conditions.Add(new ConditionExpression("operation", ConditionOperator.Equal, 3));
            query.Criteria.Conditions.Add(new ConditionExpression("createdon", ConditionOperator.GreaterEqual, dateTime_From.Value.ToString("yyyy-MM-dd")));
            query.Criteria.Conditions.Add(new ConditionExpression("createdon", ConditionOperator.LessThan, dateTime_To.Value.AddDays(1).ToString("yyyy-MM-dd")));
            query.Criteria.Conditions.Add(new ConditionExpression("objecttypecode", ConditionOperator.Equal, objectTypeCode));
            return query;
        }
        #endregion   
    }
}