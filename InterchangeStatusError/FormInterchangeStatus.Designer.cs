
namespace InterchangeStatusError
{
	partial class FormInterchangeStatus
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelCSV = new System.Windows.Forms.Label();
			this.textBoxCSV = new System.Windows.Forms.TextBox();
			this.buttonSelectFile = new System.Windows.Forms.Button();
			this.richTextBoxMessages = new System.Windows.Forms.RichTextBox();
			this.buttonLoadCSV = new System.Windows.Forms.Button();
			this.buttonInsert = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.radioButtonBeforeFix = new System.Windows.Forms.RadioButton();
			this.radioButtonAfterFix = new System.Windows.Forms.RadioButton();
			this.labelServer = new System.Windows.Forms.Label();
			this.labelDatabase = new System.Windows.Forms.Label();
			this.comboBoxDatabase = new System.Windows.Forms.ComboBox();
			this.comboBoxServer = new System.Windows.Forms.ComboBox();
			this.progressBarInsert = new System.Windows.Forms.ProgressBar();
			this.comboBoxVersion = new System.Windows.Forms.ComboBox();
			this.labelVersion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.labelTitle.Location = new System.Drawing.Point(160, 9);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(136, 21);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Interchange Tester";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCSV
			// 
			this.labelCSV.AutoSize = true;
			this.labelCSV.Location = new System.Drawing.Point(12, 41);
			this.labelCSV.Name = "labelCSV";
			this.labelCSV.Size = new System.Drawing.Size(67, 15);
			this.labelCSV.TabIndex = 1;
			this.labelCSV.Text = "Source CSV";
			// 
			// textBoxCSV
			// 
			this.textBoxCSV.Location = new System.Drawing.Point(95, 33);
			this.textBoxCSV.Name = "textBoxCSV";
			this.textBoxCSV.Size = new System.Drawing.Size(294, 23);
			this.textBoxCSV.TabIndex = 2;
			// 
			// buttonSelectFile
			// 
			this.buttonSelectFile.BackColor = System.Drawing.Color.CornflowerBlue;
			this.buttonSelectFile.Location = new System.Drawing.Point(410, 33);
			this.buttonSelectFile.Name = "buttonSelectFile";
			this.buttonSelectFile.Size = new System.Drawing.Size(35, 23);
			this.buttonSelectFile.TabIndex = 3;
			this.buttonSelectFile.Text = "...";
			this.buttonSelectFile.UseVisualStyleBackColor = false;
			this.buttonSelectFile.Click += new System.EventHandler(this.ButtonSelectFile_Click);
			// 
			// richTextBoxMessages
			// 
			this.richTextBoxMessages.Location = new System.Drawing.Point(95, 198);
			this.richTextBoxMessages.Name = "richTextBoxMessages";
			this.richTextBoxMessages.Size = new System.Drawing.Size(294, 108);
			this.richTextBoxMessages.TabIndex = 4;
			this.richTextBoxMessages.Text = "";
			// 
			// buttonLoadCSV
			// 
			this.buttonLoadCSV.BackColor = System.Drawing.Color.CornflowerBlue;
			this.buttonLoadCSV.Location = new System.Drawing.Point(95, 378);
			this.buttonLoadCSV.Name = "buttonLoadCSV";
			this.buttonLoadCSV.Size = new System.Drawing.Size(65, 43);
			this.buttonLoadCSV.TabIndex = 5;
			this.buttonLoadCSV.Text = "Load CSV";
			this.buttonLoadCSV.UseVisualStyleBackColor = false;
			this.buttonLoadCSV.Click += new System.EventHandler(this.buttonLoadCSV_Click);
			// 
			// buttonInsert
			// 
			this.buttonInsert.BackColor = System.Drawing.Color.CornflowerBlue;
			this.buttonInsert.Location = new System.Drawing.Point(211, 378);
			this.buttonInsert.Name = "buttonInsert";
			this.buttonInsert.Size = new System.Drawing.Size(65, 43);
			this.buttonInsert.TabIndex = 6;
			this.buttonInsert.Text = "Insert Data";
			this.buttonInsert.UseVisualStyleBackColor = false;
			this.buttonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.BackColor = System.Drawing.Color.CornflowerBlue;
			this.buttonSave.Location = new System.Drawing.Point(324, 378);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(65, 43);
			this.buttonSave.TabIndex = 7;
			this.buttonSave.Text = "Save Output";
			this.buttonSave.UseVisualStyleBackColor = false;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
			// 
			// radioButtonBeforeFix
			// 
			this.radioButtonBeforeFix.AutoSize = true;
			this.radioButtonBeforeFix.Location = new System.Drawing.Point(95, 132);
			this.radioButtonBeforeFix.Name = "radioButtonBeforeFix";
			this.radioButtonBeforeFix.Size = new System.Drawing.Size(75, 19);
			this.radioButtonBeforeFix.TabIndex = 8;
			this.radioButtonBeforeFix.TabStop = true;
			this.radioButtonBeforeFix.Text = "Before fix";
			this.radioButtonBeforeFix.UseVisualStyleBackColor = true;
			// 
			// radioButtonAfterFix
			// 
			this.radioButtonAfterFix.AutoSize = true;
			this.radioButtonAfterFix.Location = new System.Drawing.Point(95, 157);
			this.radioButtonAfterFix.Name = "radioButtonAfterFix";
			this.radioButtonAfterFix.Size = new System.Drawing.Size(67, 19);
			this.radioButtonAfterFix.TabIndex = 9;
			this.radioButtonAfterFix.TabStop = true;
			this.radioButtonAfterFix.Text = "After fix";
			this.radioButtonAfterFix.UseVisualStyleBackColor = true;
			this.radioButtonAfterFix.CheckedChanged += new System.EventHandler(this.radioButtonAfterFix_CheckedChanged);
			// 
			// labelServer
			// 
			this.labelServer.AutoSize = true;
			this.labelServer.Location = new System.Drawing.Point(14, 70);
			this.labelServer.Name = "labelServer";
			this.labelServer.Size = new System.Drawing.Size(65, 15);
			this.labelServer.TabIndex = 10;
			this.labelServer.Text = "Dest Server";
			// 
			// labelDatabase
			// 
			this.labelDatabase.AutoSize = true;
			this.labelDatabase.Location = new System.Drawing.Point(31, 99);
			this.labelDatabase.Name = "labelDatabase";
			this.labelDatabase.Size = new System.Drawing.Size(48, 15);
			this.labelDatabase.TabIndex = 11;
			this.labelDatabase.Text = "Dest DB";
			// 
			// comboBoxDatabase
			// 
			this.comboBoxDatabase.AutoCompleteCustomSource.AddRange(new string[] {
            "localhost"});
			this.comboBoxDatabase.FormattingEnabled = true;
			this.comboBoxDatabase.Items.AddRange(new object[] {
            "EMISWebCR10",
            "EMISWebCR2"});
			this.comboBoxDatabase.Location = new System.Drawing.Point(95, 91);
			this.comboBoxDatabase.Name = "comboBoxDatabase";
			this.comboBoxDatabase.Size = new System.Drawing.Size(294, 23);
			this.comboBoxDatabase.TabIndex = 13;
			// 
			// comboBoxServer
			// 
			this.comboBoxServer.FormattingEnabled = true;
			this.comboBoxServer.Items.AddRange(new object[] {
            "localhost"});
			this.comboBoxServer.Location = new System.Drawing.Point(95, 62);
			this.comboBoxServer.Name = "comboBoxServer";
			this.comboBoxServer.Size = new System.Drawing.Size(294, 23);
			this.comboBoxServer.TabIndex = 14;
			// 
			// progressBarInsert
			// 
			this.progressBarInsert.BackColor = System.Drawing.Color.White;
			this.progressBarInsert.ForeColor = System.Drawing.Color.MidnightBlue;
			this.progressBarInsert.Location = new System.Drawing.Point(95, 327);
			this.progressBarInsert.Name = "progressBarInsert";
			this.progressBarInsert.Size = new System.Drawing.Size(294, 28);
			this.progressBarInsert.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBarInsert.TabIndex = 15;
			// 
			// comboBoxVersion
			// 
			this.comboBoxVersion.FormattingEnabled = true;
			this.comboBoxVersion.Items.AddRange(new object[] {
            "Original",
            "V2",
            "V3",
            "V4",
            "V5"});
			this.comboBoxVersion.Location = new System.Drawing.Point(245, 157);
			this.comboBoxVersion.Name = "comboBoxVersion";
			this.comboBoxVersion.Size = new System.Drawing.Size(144, 23);
			this.comboBoxVersion.TabIndex = 16;
			this.comboBoxVersion.SelectedIndexChanged += new System.EventHandler(this.comboBoxVersion_SelectedIndexChanged);
			// 
			// labelVersion
			// 
			this.labelVersion.AutoSize = true;
			this.labelVersion.Location = new System.Drawing.Point(176, 160);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(45, 15);
			this.labelVersion.TabIndex = 17;
			this.labelVersion.Text = "Version";
			// 
			// FormInterchangeStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(466, 448);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.comboBoxVersion);
			this.Controls.Add(this.progressBarInsert);
			this.Controls.Add(this.comboBoxServer);
			this.Controls.Add(this.comboBoxDatabase);
			this.Controls.Add(this.labelDatabase);
			this.Controls.Add(this.labelServer);
			this.Controls.Add(this.radioButtonAfterFix);
			this.Controls.Add(this.radioButtonBeforeFix);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonInsert);
			this.Controls.Add(this.buttonLoadCSV);
			this.Controls.Add(this.richTextBoxMessages);
			this.Controls.Add(this.buttonSelectFile);
			this.Controls.Add(this.textBoxCSV);
			this.Controls.Add(this.labelCSV);
			this.Controls.Add(this.labelTitle);
			this.Name = "FormInterchangeStatus";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelCSV;
		private System.Windows.Forms.TextBox textBoxCSV;
		private System.Windows.Forms.Button buttonSelectFile;
		private System.Windows.Forms.RichTextBox richTextBoxMessages;
		private System.Windows.Forms.Button buttonLoadCSV;
		private System.Windows.Forms.Button buttonInsert;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.RadioButton radioButtonBeforeFix;
		private System.Windows.Forms.RadioButton radioButtonAfterFix;
		private System.Windows.Forms.Label labelServer;
		private System.Windows.Forms.Label labelDatabase;
		private System.Windows.Forms.ComboBox comboBoxDatabase;
		private System.Windows.Forms.ComboBox comboBoxServer;
		private System.Windows.Forms.ProgressBar progressBarInsert;
		private System.Windows.Forms.ComboBox comboBoxVersion;
		private System.Windows.Forms.Label labelVersion;
	}
}

