using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterchangeStatusError
{
	public partial class FormInterchangeStatus : Form
	{
		InterchangeLoader myInterchangeLoader;
		SourceFileInsertion mySourceFileInsertion;
		BackgroundWorker bg_InterchangeLoader;
		BackgroundWorker bg_SourceFileInsertion;

		public delegate void CallbackMessage(string message);
		public delegate void CallbackPercentage(int percentage, int total, int processed);

		bool loaderSucceeded = false;
		public FormInterchangeStatus()
		{
			InitializeComponent();
			buttonInsert.Enabled = false;
			buttonSave.Enabled = false;
			comboBoxVersion.SelectedItem = "Original";
			comboBoxVersion.Enabled = false;
			radioButtonBeforeFix.Checked = true;

			comboBoxServer.SelectedItem = "localhost";
			comboBoxDatabase.SelectedItem = "EMISWebCR10";

			bg_InterchangeLoader = new BackgroundWorker();
			bg_InterchangeLoader.DoWork += Bg_InterchangeLoader_DoWork;
			bg_InterchangeLoader.RunWorkerCompleted += Bg_InterchangeLoader_RunWorkerCompleted;

			bg_SourceFileInsertion = new BackgroundWorker();
			bg_SourceFileInsertion.DoWork += Bg_SourceFileInsertion_DoWork;
		}

		private void buttonLoadCSV_Click(object sender, EventArgs e)
		{
			richTextBoxMessages.Clear();

			if (textBoxCSV.Text.Length > 0)
			{
				myInterchangeLoader = new InterchangeLoader(textBoxCSV.Text);
				myInterchangeLoader.StatusUpdate += new InterchangeLoader._delStatusUpdate(InterchangeLoader_StatusUpdate);

				bg_InterchangeLoader.RunWorkerAsync();
			}
		}

		private void Bg_InterchangeLoader_DoWork(object sender, DoWorkEventArgs e)
		{
			bool csvImported = myInterchangeLoader.LoadData();

			if (!csvImported)
			{
				e.Cancel = true;
			}
		}
		private void Bg_InterchangeLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				buttonInsert.Enabled = true;
				buttonSave.Enabled = true;
				loaderSucceeded = true;
			}
		}
		private void InterchangeLoader_StatusUpdate(string message)
		{
			if (richTextBoxMessages.InvokeRequired)
			{
				CallbackMessage cb = new CallbackMessage(InterchangeLoader_StatusUpdate);
				this.Invoke(cb, new object[] { message });
			}
			else
			{
				richTextBoxMessages.Text = richTextBoxMessages.Text + message;
				richTextBoxMessages.SelectionStart = richTextBoxMessages.Text.Length;
				richTextBoxMessages.ScrollToCaret();
			}
		}
		private void SourceFileInsertion_StatusUpdate(string message)
		{
			if (richTextBoxMessages.InvokeRequired)
			{
				CallbackMessage cb = new CallbackMessage(SourceFileInsertion_StatusUpdate);
				this.Invoke(cb, new object[] { message });
			}
			else
			{
				richTextBoxMessages.Text = richTextBoxMessages.Text + message;
				richTextBoxMessages.SelectionStart = richTextBoxMessages.Text.Length;
				richTextBoxMessages.ScrollToCaret();
			}
		}

		private void ButtonSelectFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = "C:\\Users\\David.Unsworth\\Documents\\Bugs & Incidents\\Bug 242028 Duplicate key error generated\\Real data";
			openFileDialog1.Filter = "csv files (*.csv)|*.csv";

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBoxCSV.Text = openFileDialog1.FileName;
			}
			else
			{
				textBoxCSV.Text = string.Empty;
			}
		}

		private void ButtonInsert_Click(object sender, EventArgs e)
		{
			if (loaderSucceeded)
			{
				mySourceFileInsertion = new SourceFileInsertion(myInterchangeLoader.Source_CSV, comboBoxServer.Text, comboBoxDatabase.Text, radioButtonBeforeFix.Checked, comboBoxVersion.Text);
				mySourceFileInsertion.StatusUpdate += new SourceFileInsertion._delStatusUpdate(SourceFileInsertion_StatusUpdate);
				mySourceFileInsertion.OnProgressUpdate += new SourceFileInsertion.ProgressUpdate(SourceFileInsertion_OnProgressUpdate);
				bg_SourceFileInsertion.RunWorkerAsync();				
			}
		}
		private void Bg_SourceFileInsertion_DoWork(object sender, DoWorkEventArgs e)
		{
			mySourceFileInsertion.InsertData();
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			SaveFileDialog mySaveFileDialog = new SaveFileDialog();

			string fileNamePrefix = GetPrefix();

			mySaveFileDialog.FileName = fileNamePrefix + "_" + DateTime.Now.Day.ToString("00") +
					DateTime.Now.Month.ToString("00") + DateTime.Now.Year.ToString().Substring(2) +
					"_" + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + ".txt";

			mySaveFileDialog.Filter = "Text files (*.txt)|*.txt";

			mySaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string folderPathAndFileName = mySaveFileDialog.FileName;
				richTextBoxMessages.SaveFile(folderPathAndFileName, RichTextBoxStreamType.PlainText);
			}
		}

		private string GetPrefix()
		{
			string prefix = string.Empty;

			switch (comboBoxVersion.SelectedItem)
			{
				case "Original":
					prefix = "Test_original";
					break;
				case "V2":
					prefix = "Test_sp_getapplock_result_check";
					break;
				case "V3":
					prefix = "Test_sp_getapplock";
					break;
				case "V4":
					prefix = "Test_sp_getapplock_failure_check";
					break;
				case "V5":
					prefix = "Test_sp_getapplock_copilot";
					break;
			}

			return prefix;
		}

		private void SourceFileInsertion_OnProgressUpdate(int percentage, int totalDocuments, int processedDocuments)
		{
			if (progressBarInsert.InvokeRequired)
			{
				CallbackPercentage cb = new CallbackPercentage(SourceFileInsertion_OnProgressUpdate);
				this.Invoke(cb, new object[] { percentage, totalDocuments, processedDocuments });
			}
			else
			{
				progressBarInsert.Value = percentage;
			}
		}

		private void radioButtonAfterFix_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonAfterFix.Checked)
			{
				comboBoxVersion.Enabled = true;
			}
			else
			{
				comboBoxVersion.SelectedItem = "Original";
				comboBoxVersion.Enabled = false;
			}
		}

		private void comboBoxVersion_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBoxVersion.SelectedItem)
			{
				case "V2":
					MessageBox.Show("Testing sp_getapplock with lock result check.", "Information");
					break;
				case "V3":
					MessageBox.Show("Testing sp_getapplock with a lock per interchange", "Information");
					break;
				case "V4":
					MessageBox.Show("Testing sp_getapplock with lock failure check.", "Information");
					break;
				case "V5":
					MessageBox.Show("Testing sp_getapplock copilot version.", "Information");
					break;
			}
		}
	}
}
