using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace InterchangeStatusError
{
	public class TradingPartnerData
	{
		private Int32? interchangeId;
		private Int32? interchangeStatusHistoryId;
		private Guid InterchangeGuid = Guid.NewGuid();
		public void InterchangeInsert(DataRow status, SqlConnection connection)
		{
			using (SqlCommand insertCommand = new SqlCommand("Comms.InterchangeInsert", connection))
			{
				insertCommand.CommandType = CommandType.StoredProcedure;

				insertCommand.Parameters.Add("@OrganisationId", SqlDbType.Int);
				insertCommand.Parameters.Add("@InterchangeGUID", SqlDbType.UniqueIdentifier);
				insertCommand.Parameters.Add("@TradingPartnerOrganisationId", SqlDbType.Int);
				insertCommand.Parameters.Add("@InterchangeDate", SqlDbType.DateTime);
				insertCommand.Parameters.Add("@Direction", SqlDbType.TinyInt);
				insertCommand.Parameters.Add("@Type", SqlDbType.TinyInt);
				insertCommand.Parameters.Add("@MessageType", SqlDbType.TinyInt);
				insertCommand.Parameters.Add("@MessageTypeVersion", SqlDbType.TinyInt);
				insertCommand.Parameters.Add("@InterchangeId", SqlDbType.Int);
				insertCommand.Parameters.Add("@SenderId", SqlDbType.VarChar);
				insertCommand.Parameters.Add("@RecipientId", SqlDbType.VarChar);
				insertCommand.Parameters.Add("@Number", SqlDbType.VarChar);
				insertCommand.Parameters.Add("@Data", SqlDbType.VarChar);

				insertCommand.Parameters["@OrganisationId"].Value = 3018;
				insertCommand.Parameters["@InterchangeGUID"].Value = (object)InterchangeGuid;
				insertCommand.Parameters["@TradingPartnerOrganisationId"].Value = (object)39;
				insertCommand.Parameters["@InterchangeDate"].Value = DateTime.Now;
				insertCommand.Parameters["@Direction"].Value = 1;
				insertCommand.Parameters["@Type"].Value = 5;
				insertCommand.Parameters["@MessageType"].Value = 2;
				insertCommand.Parameters["@MessageTypeVersion"].Value = 6;
				insertCommand.Parameters["@InterchangeId"].Value = DBNull.Value;
				insertCommand.Parameters["@SenderId"].Value = "180000017300001";
				insertCommand.Parameters["@RecipientId"].Value = "180009001500005";
				insertCommand.Parameters["@Number"].Value = "00008788";
				insertCommand.Parameters["@Data"].Value = "UNA:+.?";

				insertCommand.ExecuteNonQuery();

				if (insertCommand.Parameters["@InterchangeId"].Value != DBNull.Value)
					interchangeId = (int)insertCommand.Parameters["@InterchangeId"].Value;
			}
		}
		public void InterchangeStatusHistoryInsert(DataRow status, SqlConnection connection, string storedProcedureCalled)
		{
			if (interchangeStatusHistoryId == null)
			{
				using (SqlCommand insertCommand = new SqlCommand(storedProcedureCalled, connection))
				{
					insertCommand.CommandType = CommandType.StoredProcedure;

					insertCommand.Parameters.Add("@InterchangeGUID", SqlDbType.UniqueIdentifier);
					insertCommand.Parameters.Add("@InterchangeId", SqlDbType.Int);
					insertCommand.Parameters.Add("@Status", SqlDbType.TinyInt);
					insertCommand.Parameters.Add("@StatusDescription", SqlDbType.VarChar);
					insertCommand.Parameters.Add("@StatusDate", SqlDbType.DateTime);
					insertCommand.Parameters.Add("@InterchangeStatusHistoryId", SqlDbType.Int);

					insertCommand.Parameters["@InterchangeGUID"].Value = DBNull.Value;
					insertCommand.Parameters["@InterchangeId"].Value = Convert.ToInt32(status["InterchangeId"]);//(object)interchangeId ?? DBNull.Value;
					insertCommand.Parameters["@Status"].Value = Convert.ToInt32(status["Status"]);

					if (status["StatusDescription"] != DBNull.Value)
					{
						insertCommand.Parameters["@StatusDescription"].Value = status["StatusDescription"].ToString().Trim();
					}

					if (DateTime.TryParse(status["StatusDate"].ToString(), out DateTime dateValue))
					{
						insertCommand.Parameters["@StatusDate"].Value = dateValue;
					}

					insertCommand.Parameters["@InterchangeStatusHistoryId"].Value = DBNull.Value;

					insertCommand.ExecuteNonQuery();

					if (insertCommand.Parameters["@InterchangeStatusHistoryId"].Value != DBNull.Value)
						interchangeStatusHistoryId = (int)insertCommand.Parameters["@InterchangeStatusHistoryId"].Value;
				}
			}
		}
	}
}
