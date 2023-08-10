# Data Restoration Tool
The purpose of this tool is to be able to restore deleted Dataverse data.
The tool will only list the tables that have auditing enabled and show records that are eligible to be restored.

## Prerequisite
To be able to work with this tool, make sure that the table you want to restore records for has auditing enabled!
For more information on auditing in Dataverse, visit https://learn.microsoft.com/en-us/power-platform/admin/manage-dataverse-auditing.

## How to use the tool
When loading in the tool, make sure you are connected to a Dataverse environment.
Once you are connected, the tables that have auditing enabled will be loaded in the "Select Table" dropdown.

Proceed by selecting the desired table and Date Range to load the deleted records from and press the "Load Deleted Records" button.
The first grid will be filled with the Audit Items regarding the deleted records.
Clicking on the record name (Record column) will display additional information for this record in the right grid.
This contains a detailed view on what the data for this specific record looked like.

Select the records you want to restore by checking them in the first column.
From the moment you have atleast one record selected you will be able to Restore these records by clicking the "Resotre Selected Data" button.

Note that there are  options available under the Advanced Settings.
- **ByPass Custom Plugin Execution** -  With this option enabled the requests will ignore any custom made plugins allowing for faster insertion of the data and also avoiding any unwanted data modification due to custom plugins (This does not include standard Microsoft plugins!)
- **Bypass Power Automate Flow** - With this option enabled the requests will ignore any Power Automate Flow triggers in the background. This refers to Power Automate flows that trigger on record create of the selected table.
- **Reuse deleted GUID** - with this option enabled, the requests will use the GUID from the deleted record, making the restoration of any past references possible. This provides more data consistency. Disable this option if you want to iniate a Create request with a new, Dynamics generated GUID.
- **Continue on error** - With this option enabled the restoration of multiple records will not stop after an error has occured. Instead it will write the errors to the Log File which can be reviewed later. With the option disabled, once an error has been encoutnered, this error will be reported directly and further records will not be restored.

For more information on these settings please visit: https://learn.microsoft.com/en-us/power-apps/developer/data-platform/bypass-custom-business-logic?tabs=sdk