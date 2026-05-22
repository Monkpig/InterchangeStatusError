using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InterchangeStatusError
{
	class SourceFileInsertion
	{
		private readonly DataTable _Source_CSV;
		private readonly string _destinationConnectionString;
		private readonly string _procedureVersion;
		readonly TradingPartnerData tradingPartnerData = new TradingPartnerData();
		private readonly bool _beforeFix;
		private const int REPEAT_INSERT = 500;

		public delegate void _delStatusUpdate(string message);
		public event _delStatusUpdate StatusUpdate;

		public delegate void ProgressUpdate(int percentage, int total, int processed);
		public event ProgressUpdate OnProgressUpdate;

		public SourceFileInsertion(DataTable Source_CSV, string serverName, string databaseName, bool beforeFix, string procedureVersion)
		{
			_Source_CSV = Source_CSV;
			_destinationConnectionString = "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";Integrated Security=SSPI;TrustServerCertificate=True;";
			_beforeFix = beforeFix;
			_procedureVersion = GetFullName(procedureVersion);
		}

		private string GetFullName(string procedureVersion)
		{
			string fullName;

			if (procedureVersion.Length == 2)
			{
				fullName = $"Comms.InterchangeStatusHistoryInsert{procedureVersion}";
			}
			else
			{
				fullName = "Comms.InterchangeStatusHistoryInsert";
			}

			return fullName;
		}

		public void InsertData()
		{
			bool success = false;

			try
			{
				StatusUpdate($"Begin inserting data : {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}{Environment.NewLine}{Environment.NewLine}");
				var _destinationConnection = new SqlConnection(_destinationConnectionString);
				_destinationConnection.Open();

				//tradingPartnerData.InterchangeInsert(_Source_CSV.Rows[0], _destinationConnection);

				int i = 0;
				int count = 0;
				int rowsToInsert = REPEAT_INSERT * _Source_CSV.Rows.Count;

				do
				{
					foreach (DataRow currentRow in _Source_CSV.Rows)
					{
						try
						{
							tradingPartnerData.InterchangeStatusHistoryInsert(currentRow, _destinationConnection, _procedureVersion);
							count++;
							int percentage = count * 100 / rowsToInsert;
							OnProgressUpdate(percentage, rowsToInsert, count);
						}
						catch (Exception ex)
						{
							StatusUpdate($"Error processing row {count}: {ex.Message}{Environment.NewLine}");
						}
					}
					i++;
				}
				while (i < REPEAT_INSERT);
			}
			catch (Exception ex)
			{
				StatusUpdate($"Error inserting data: {ex.Message}{Environment.NewLine}");
			}

			StatusUpdate($"End inserting data : {DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}{Environment.NewLine}{Environment.NewLine}");
		}
	}
}
