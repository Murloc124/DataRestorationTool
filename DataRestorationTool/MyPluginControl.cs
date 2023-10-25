using DataRestorationTool.Model;
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
using XrmToolBox.Extensibility.Interfaces;

namespace DataRestorationTool
{
    public partial class MyPluginControl : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        #region Private Properties
        private List<EntityMetadata> tableMetaDataList;
        #endregion

        #region Public Proprties
        // Github Properties
        public string RepositoryName => "DataRestorationTool";
        public string UserName => "Murloc124";

        // PayPal Properties
        public string DonationDescription => "Help us improve thist tool!";
        string IPayPalPlugin.EmailAccount => "dominica3000@gmail.com";

        public Settings settings;
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
            if (SettingsManager.Instance.TryLoad(typeof(MyPlugin), out settings))
            {
                cb_PlgnExec.Checked = settings.ByPassCustomPlugin;
                cb_PAFlow.Checked = settings.ByPassPAFlow;
                cb_ContinueOnError.Checked = settings.ContinueOnError;
                cb_ReuseGUID.Checked = settings.ReuseOldGuid;
            }
            else
                settings = new Settings();
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
            if (!cb_RetrieveAll.Checked && dateTime_From.Value > dateTime_To.Value)
            {
                MessageBox.Show("Please select a From Date earlier or equal to the To Date");
                return;
            }

            EnableControls(false);
            LoadAuditData((Tuple<int, string, string>)combo_Tables.SelectedItem, combo_Tables.SelectedValue);
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

                foreach (DataGridViewRow row in dataGrid_DeletedRecords.Rows)
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

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < dataGrid_DeletedRecords.Rows.Count; c++)
            {
                var row = dataGrid_DeletedRecords.Rows[c];
                var checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];

                checkBoxCell.Value = true;
            }
            tsb_RestoreData.Enabled = true;
        }

        private void btn_DeselectAll_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < dataGrid_DeletedRecords.Rows.Count; c++)
            {
                var row = dataGrid_DeletedRecords.Rows[c];
                var checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];

                checkBoxCell.Value = false;
            }
            tsb_RestoreData.Enabled = false;
        }

        private void cb_RetrieveAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_RetrieveAll.Checked)
            {
                dateTime_From.Enabled = false;
                dateTime_To.Enabled = false;
            } else
            {
                dateTime_From.Enabled = true;
                dateTime_To.Enabled = true;
            }
        }
        #endregion

        #region Logic
        private void WhoAmI() => Service.Execute(new WhoAmIRequest());

        private void EnableControls(bool enabled = true)
        {
            combo_Tables.Enabled = enabled;
            cb_RetrieveAll.Enabled = enabled;
            dateTime_From.Enabled = enabled && !cb_RetrieveAll.Checked;
            dateTime_To.Enabled = enabled && !cb_RetrieveAll.Checked;
            tsb_LoadAudit.Enabled = enabled;
            btn_SelectAll.Enabled = enabled;
            btn_DeselectAll.Enabled = enabled;
        }

        private void LoadTableData()
        {
            ExecuteMethod(WhoAmI);

            var dataResultTables = new List<Tuple<int, string, string>>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Loading Tables with Auditing enabled...",
                Work = (w, e) =>
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

                    e.Result = dataResultTables.OrderBy(_ => _.Item2).ToList();
                },
                PostWorkCallBack = ev =>
                {
                    combo_Tables.DataSource = ev.Result;
                    combo_Tables.DisplayMember = "Item2";
                    combo_Tables.ValueMember = "Item1";

                    EnableControls();
                    btn_SelectAll.Enabled = false;
                    btn_DeselectAll.Enabled = false;
                },
                IsCancelable = false, AsyncArgument = null
            });
        }

        private void LoadAuditData(Tuple<int, string, string> selectedTable, object selectedTableValue)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Deleted Records..",
                Work = (w, e) =>
                {
                    var result = new List<AuditItem>();
                    var queryResult = ExecutePagedQuery(BuildAuditQuery(selectedTableValue));

                    foreach (var item in queryResult)
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
                            Name = selectedTable.Item3 != null && auditDetail.OldValue.Contains(selectedTable.Item3) ? auditDetail.OldValue[selectedTable.Item3].ToString() : "[EMPTY NAME]",
                        });
                        w.ReportProgress(-1, $"Loaded {result.Count} / {queryResult.Count} records..");
                    }

                    e.Result = result.OrderByDescending(_ => _.DeletionDate).ToList();
                },
                ProgressChanged = e => SetWorkingMessage(e.UserState.ToString()),
                PostWorkCallBack = e =>
                {
                    EnableControls();

                    if (((List<AuditItem>)e.Result).Count == 0)
                    {
                        MessageBox.Show($"No deleted records for table {selectedTable.Item2} during the selected period.");
                        dataGrid_DeletedRecords.DataSource = null;
                        btn_SelectAll.Enabled = false;
                        btn_DeselectAll.Enabled = false;
                    }
                    else
                        dataGrid_DeletedRecords.DataSource = e.Result;
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
            ExecuteMultipleResponse empResponse;
            bool byPassPlgn = cb_PlgnExec.Checked;
            bool byPassFlow = cb_PAFlow.Checked;
            bool reuseGUID = cb_ReuseGUID.Checked;
            bool contOnErr = cb_ContinueOnError.Checked;
            List<string> errorList = new List<string>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Restoring Deleted Data..",
                Work = (w, e) =>
                {
                    try
                    {
                        var emp = IntializeExecuteMultipleRequest();
                        var restoredRecordCount = 0;

                        for (int c = 0; c < dataGrid_DeletedRecords.Rows.Count; c++)
                        {
                            var row = dataGrid_DeletedRecords.Rows[c];
                            var checkBoxCell = (DataGridViewCheckBoxCell)row.Cells[0];

                            if (checkBoxCell.Value != null && (bool)checkBoxCell.Value)
                            {
                                emp.Requests.Add(BuildCreateRequest((AuditItem)row.DataBoundItem, reuseGUID, byPassPlgn, byPassFlow));

                                if (emp.Requests.Count >= 250)
                                {
                                    empResponse = (ExecuteMultipleResponse)Service.Execute(emp);

                                    errorList = HandleEMPReponse(empResponse.Responses, contOnErr, errorList);

                                    emp = IntializeExecuteMultipleRequest();
                                }
                                w.ReportProgress(-1, $"Restoring {++restoredRecordCount} Records..");
                            }
                        }

                        empResponse = (ExecuteMultipleResponse)Service.Execute(emp);

                        errorList = HandleEMPReponse(empResponse.Responses, contOnErr, errorList);

                        if (errorList.Count > 0)
                            e.Result = errorList;
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                },
                ProgressChanged = e => SetWorkingMessage($"Restoring Deleted Data..\n{e.UserState}"),
                PostWorkCallBack = e =>
                {
                    if (e.Result is null)
                    {
                        MessageBox.Show("Record(s) restored succesfully!");
                    }
                    else if (e.Result.GetType() == typeof(Exception))
                    {
                        ShowErrorDialog((Exception)e.Result, "Failed to Restore record(s)", allownewissue: true);
                    } else
                    {
                        LogInfo("Multiple errors have occurred while restoring the data");
                        ((List<string>)e.Result).ForEach(r =>
                        {
                            LogError(r);
                        });

                        if (MessageBox.Show("Multiple errors have occurred while restoring the data. Do you wish to view the Log File?", "Confirmation", MessageBoxButtons.YesNo).ToString().ToUpper() == "YES")
                            OpenLogFile();
                    }
                },
                IsCancelable = true
            });
        }

        private CreateRequest BuildCreateRequest(AuditItem auditItem, bool reuseGuid, bool byPassPlgn, bool byPassFlow)
        {
            var eToCreate = auditItem.AuditDetail.OldValue;
            eToCreate.Attributes.Remove("statecode");
            eToCreate.Attributes.Remove("statuscode");

            if (reuseGuid) eToCreate.Id = auditItem.RecordId;

            var req = new CreateRequest { Target = eToCreate };

            if (byPassPlgn) req.Parameters.Add("BypassCustomPluginExecution", true);
            if (byPassFlow) req.Parameters.Add("SuppressCallbackRegistrationExpanderJob", true);

            return req;
        }

        private List<string> HandleEMPReponse(ExecuteMultipleResponseItemCollection responses, bool contOnError, List<string> errorList)
        {
            if (responses.Count == 0)
                return errorList;

            if (!contOnError)
            {
                throw new Exception(responses.First().Fault.Message);
            }

            foreach (var resp in responses)
                errorList.Add(resp.Fault.Message);

            return errorList;
        }

        private ExecuteMultipleRequest IntializeExecuteMultipleRequest() =>
            new ExecuteMultipleRequest
            {
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = cb_ContinueOnError.Checked,
                    ReturnResponses = false,
                },
                Requests = new OrganizationRequestCollection(),
            };

        private List<Entity> ExecutePagedQuery(QueryExpression q)
        {
            int pageNumber = 1;
            string pagingCookie = null;

            DataCollection<Entity> result = null;
            while (true)
            {
                q.PageInfo = new PagingInfo() { Count = 500, PageNumber = pageNumber, PagingCookie = pagingCookie };
                EntityCollection ec = Service.RetrieveMultiple(q);

                if (object.ReferenceEquals(result, null)) result = ec.Entities;
                else result.AddRange(ec.Entities);

                if (!ec.MoreRecords) break;
                else
                {
                    pageNumber++;
                    pagingCookie = ec.PagingCookie;
                }
            }

            return result.ToList();
        } 
        #endregion

        #region QueryExpressions
        private QueryExpression BuildAuditQuery(object objectTypeCode)
        {
            var query = new QueryExpression("audit");
            query.ColumnSet = new ColumnSet("auditid", "regardingobjectid", "createdon", "userid", "objectid", "objecttypecode", "action");
            query.Criteria.Conditions.Add(new ConditionExpression("operation", ConditionOperator.Equal, 3));
            if (!cb_RetrieveAll.Checked)
            {
                query.Criteria.Conditions.Add(new ConditionExpression("createdon", ConditionOperator.GreaterEqual, dateTime_From.Value.ToString("yyyy-MM-dd")));
                query.Criteria.Conditions.Add(new ConditionExpression("createdon", ConditionOperator.LessThan, dateTime_To.Value.AddDays(1).ToString("yyyy-MM-dd")));
            }
            query.Criteria.Conditions.Add(new ConditionExpression("objecttypecode", ConditionOperator.Equal, objectTypeCode));
            return query;
        }
        #endregion

        #region Overrides
        public override void ClosingPlugin(PluginCloseInfo info)
        {
            settings.ByPassCustomPlugin = cb_PlgnExec.Checked;
            settings.ByPassPAFlow = cb_PAFlow.Checked;
            settings.ContinueOnError = cb_ContinueOnError.Checked;
            settings.ReuseOldGuid = cb_ReuseGUID.Checked;

            SettingsManager.Instance.Save(typeof(MyPlugin), settings);

            if (!info.Silent && info.FormReason == CloseReason.None && info.ToolBoxReason != ToolBoxCloseReason.CloseAll && info.ToolBoxReason != ToolBoxCloseReason.CloseAllExceptActive)
            {
                info.Cancel = MessageBox.Show("Are you sure you want to close this tab?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
            }
        }
        #endregion
    }
}