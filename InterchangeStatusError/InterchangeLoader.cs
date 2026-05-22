using System;
using System.Data;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace InterchangeStatusError
{
	public class InterchangeLoader
	{
		private readonly string _sourceCSV;
		private readonly string _rootPath;

		private readonly DataTable _Source_CSV = new DataTable();
		public DataTable Source_CSV
		{
			get { return _Source_CSV; }
		}

		private const int EXPECTED_FIELDS = 6;

		public delegate void _delStatusUpdate(string message);
		public event _delStatusUpdate StatusUpdate;

		public InterchangeLoader(string csvFile)
		{
			_sourceCSV = csvFile;
			_rootPath = csvFile.Substring(0, csvFile.LastIndexOf("\\"));
			SpecifySourceCSVColumns();
		}

		public void SpecifySourceCSVColumns()
		{
			DataColumn InterchangeGUID = new DataColumn("InterchangeGUID", typeof(string));
			DataColumn InterchangeId = new DataColumn("InterchangeId", typeof(string));
			DataColumn Status = new DataColumn("Status", typeof(string));
			DataColumn StatusDescription = new DataColumn("StatusDescription", typeof(string));
			DataColumn StatusDate = new DataColumn("StatusDate", typeof(string));
			DataColumn InterchangeStatusHistoryId = new DataColumn("InterchangeStatusHistoryId", typeof(string));

			_Source_CSV.Columns.Add(InterchangeGUID);
			_Source_CSV.Columns.Add(InterchangeId);
			_Source_CSV.Columns.Add(Status);
			_Source_CSV.Columns.Add(StatusDescription);
			_Source_CSV.Columns.Add(StatusDate);
			_Source_CSV.Columns.Add(InterchangeStatusHistoryId);
		}

		public bool LoadData()
		{
			bool success = false;

			try
			{
				StatusUpdate($"Importing the CSV : {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}{Environment.NewLine}");
				success = ReadCSVFile();
			}
			catch (Exception ex)
			{
				StatusUpdate($"Error importing the CSV: {ex.Message}{Environment.NewLine}");
				success = false;
			}

			StatusUpdate($"{Environment.NewLine}End importing the CSV : {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}{Environment.NewLine}{Environment.NewLine}");
			return success;
		}

		private bool ReadCSVFile()
		{
			string[] parts = null;

			try
			{
				string[] lines = File.ReadAllText(_sourceCSV).Split('\n');

				for (int i = 1; i < lines.Length; i++)
				{
					parts = lines[i].Split(new string[] { "," }, StringSplitOptions.None);
					if (parts.Length == EXPECTED_FIELDS)
					{
						if (parts[4].Length == 23)//(parts[4].Length == 29 || parts[4].Length == 19)
						{
							LoadCSV(parts);
						}
						else
						{
							StatusUpdate($"Date has an invalid length on row : {PutRowBackTogether(parts)} {Environment.NewLine}");
						}
					}
					else if (!(i == lines.Length - 1 && parts.Length == 1 && parts[0] == string.Empty))
					{
						StatusUpdate($"Incorrect number of fields on row : {PutRowBackTogether(parts)} {Environment.NewLine}");
					}
				}
			}
			catch (Exception ee)
			{
				StatusUpdate($"Error reading CSV file: {ee.Message}{Environment.NewLine}{Environment.NewLine}");
				return false;
			}

			return true;
		}

		private void LoadCSV(string[] parts)
		{
			DataRow theNewRow = _Source_CSV.NewRow();

			theNewRow["InterchangeGUID"] = parts[0];
			theNewRow["InterchangeId"] = parts[1];
			theNewRow["Status"] = parts[2];
			theNewRow["StatusDescription"] = parts[3];
			theNewRow["StatusDate"] = parts[4];
			theNewRow["InterchangeStatusHistoryId"] = parts[5];

			//theNewRow["InterchangeId"] = parts[1];
			//theNewRow["Status"] = parts[2];
			//theNewRow["StatusDescription"] = parts[3];
			//theNewRow["StatusDate"] = parts[4];
			//theNewRow["InterchangeStatusHistoryId"] = parts[0];

			_Source_CSV.Rows.Add(theNewRow);
		}

		private string PutRowBackTogether(string[] parts)
		{
			StringBuilder sbErrorLine = new StringBuilder();
			for (int i = 0; i < parts.Length; i++)
			{
				sbErrorLine.Append(parts[i]);
				if (i != parts.Length - 1)
				{
					sbErrorLine.Append(',');
				}
			}

			return sbErrorLine.ToString();
		}
	}
}