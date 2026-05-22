# InterchangeStatusError

Add test versions of the Comms.InterchangStatusHistoryInsert stored procedure locally with the suffix V(n) 
eg Comms.InterchangStatusHistoryInsertV1, Comms.InterchangStatusHistoryInsertV2 etc

Update test version description in comboBoxVersion_SelectedIndexChanged and GetPrefix methods.

Test by running multiple executables concurently.

This tool was successfully used to reproduced the error 'Cannot insert duplicate key' error generated for duplicate inbound acknowledgment (RECEP) interchanges for [Bug 242028](https://emisgroup.visualstudio.com/EMISWeb%20CSAT%20Release%20Train/_workitems/edit/242028).

csv input files required.

Formats - 
InterchangeGUID,InterchangeId,Status,StatusDescription,StatusDate,InterchangeStatusHistoryId

InterchangeStatusHistoryId;InterchangeId;Status;StatusDescription;StatusDate;IsLatest


