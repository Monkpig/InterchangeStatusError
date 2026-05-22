# InterchangeStatusError

Add test versions of the Comms.InterchangStatusHistoryInsert stored procedure locally with the suffix V(n) 
eg Comms.InterchangStatusHistoryInsertV1, Comms.InterchangStatusHistoryInsertV2 etc

Update test version description in comboBoxVersion_SelectedIndexChanged and GetPrefix methods.

Test by running multiple executables concurently.

This tool was successfully used to reproduced the error 'Cannot insert duplicate key' error generated for duplicate inbound acknowledgment (RECEP) interchanges for Bug 242028.

csv input files required.

Formats - 
InterchangeGUID,InterchangeId,Status,StatusDescription,StatusDate,InterchangeStatusHistoryId

InterchangeStatusHistoryId;InterchangeId;Status;StatusDescription;StatusDate;IsLatest

InterchangeId,Number,MessageType,OrganisationId,Direction,SenderId,RecipientId,Data,InterchangeDate,TradingPartnerOrganisationId,
ExternalMessagingStoreId,Type,MessageTypeVersion,GUID

