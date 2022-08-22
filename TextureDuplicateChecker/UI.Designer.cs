namespace TextureDuplicateChecker
{
    partial class UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
			this.packOneLabel = new System.Windows.Forms.Label();
			this.packTwoLabel = new System.Windows.Forms.Label();
			this.packOnePath = new System.Windows.Forms.TextBox();
			this.packTwoPath = new System.Windows.Forms.TextBox();
			this.outputTextBox = new System.Windows.Forms.RichTextBox();
			this.exportButton = new System.Windows.Forms.Button();
			this.searchButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.perfStatsLabel = new System.Windows.Forms.Label();
			this.perfTimeLog = new System.Windows.Forms.RichTextBox();
			this.duplicateCount = new System.Windows.Forms.Label();
			this.duplicateLabel = new System.Windows.Forms.Label();
			this.resetButton = new System.Windows.Forms.Button();
			this.optionsGroup = new System.Windows.Forms.GroupBox();
			this.validatePack = new System.Windows.Forms.CheckBox();
			this.fileNameLimit = new System.Windows.Forms.CheckBox();
			this.neatFilePaths = new System.Windows.Forms.CheckBox();
			this.packTwoNameTextbox = new System.Windows.Forms.TextBox();
			this.packOneNameTextbox = new System.Windows.Forms.TextBox();
			this.p2NameLabel = new System.Windows.Forms.Label();
			this.p1NameLabel = new System.Windows.Forms.Label();
			this.complexCheck = new System.Windows.Forms.CheckBox();
			this.advancedGroup = new System.Windows.Forms.GroupBox();
			this.minPerLabel = new System.Windows.Forms.Label();
			this.percentInput = new System.Windows.Forms.NumericUpDown();
			this.perLabel = new System.Windows.Forms.Label();
			this.hideFullMatches = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.optionsGroup.SuspendLayout();
			this.advancedGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.percentInput)).BeginInit();
			this.SuspendLayout();
			// 
			// packOneLabel
			// 
			this.packOneLabel.AutoSize = true;
			this.packOneLabel.Location = new System.Drawing.Point(13, 13);
			this.packOneLabel.Name = "packOneLabel";
			this.packOneLabel.Size = new System.Drawing.Size(47, 13);
			this.packOneLabel.TabIndex = 0;
			this.packOneLabel.Text = "Pack 1: ";
			// 
			// packTwoLabel
			// 
			this.packTwoLabel.AutoSize = true;
			this.packTwoLabel.Location = new System.Drawing.Point(13, 38);
			this.packTwoLabel.Name = "packTwoLabel";
			this.packTwoLabel.Size = new System.Drawing.Size(47, 13);
			this.packTwoLabel.TabIndex = 1;
			this.packTwoLabel.Text = "Pack 2: ";
			// 
			// packOnePath
			// 
			this.packOnePath.Location = new System.Drawing.Point(66, 10);
			this.packOnePath.Name = "packOnePath";
			this.packOnePath.Size = new System.Drawing.Size(348, 20);
			this.packOnePath.TabIndex = 2;
			this.packOnePath.TextChanged += new System.EventHandler(this.packPath_TextChanged);
			// 
			// packTwoPath
			// 
			this.packTwoPath.Location = new System.Drawing.Point(66, 35);
			this.packTwoPath.Name = "packTwoPath";
			this.packTwoPath.Size = new System.Drawing.Size(348, 20);
			this.packTwoPath.TabIndex = 3;
			this.packTwoPath.TextChanged += new System.EventHandler(this.packPath_TextChanged);
			// 
			// outputTextBox
			// 
			this.outputTextBox.Location = new System.Drawing.Point(12, 68);
			this.outputTextBox.Name = "outputTextBox";
			this.outputTextBox.ReadOnly = true;
			this.outputTextBox.Size = new System.Drawing.Size(615, 311);
			this.outputTextBox.TabIndex = 5;
			this.outputTextBox.Text = "";
			// 
			// exportButton
			// 
			this.exportButton.Enabled = false;
			this.exportButton.Location = new System.Drawing.Point(12, 385);
			this.exportButton.Name = "exportButton";
			this.exportButton.Size = new System.Drawing.Size(85, 23);
			this.exportButton.TabIndex = 6;
			this.exportButton.Text = "Export";
			this.exportButton.UseVisualStyleBackColor = true;
			this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
			// 
			// searchButton
			// 
			this.searchButton.Enabled = false;
			this.searchButton.Location = new System.Drawing.Point(471, 385);
			this.searchButton.Name = "searchButton";
			this.searchButton.Size = new System.Drawing.Size(156, 23);
			this.searchButton.TabIndex = 7;
			this.searchButton.Text = "Search";
			this.searchButton.UseVisualStyleBackColor = true;
			this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.perfStatsLabel);
			this.groupBox1.Controls.Add(this.perfTimeLog);
			this.groupBox1.Controls.Add(this.duplicateCount);
			this.groupBox1.Controls.Add(this.duplicateLabel);
			this.groupBox1.Location = new System.Drawing.Point(633, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(231, 190);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Stats";
			// 
			// perfStatsLabel
			// 
			this.perfStatsLabel.AutoSize = true;
			this.perfStatsLabel.Location = new System.Drawing.Point(6, 65);
			this.perfStatsLabel.Name = "perfStatsLabel";
			this.perfStatsLabel.Size = new System.Drawing.Size(59, 13);
			this.perfStatsLabel.TabIndex = 3;
			this.perfStatsLabel.Text = "Perf. Stats:";
			// 
			// perfTimeLog
			// 
			this.perfTimeLog.Location = new System.Drawing.Point(6, 81);
			this.perfTimeLog.Name = "perfTimeLog";
			this.perfTimeLog.ReadOnly = true;
			this.perfTimeLog.Size = new System.Drawing.Size(219, 96);
			this.perfTimeLog.TabIndex = 2;
			this.perfTimeLog.Text = "";
			// 
			// duplicateCount
			// 
			this.duplicateCount.Location = new System.Drawing.Point(69, 32);
			this.duplicateCount.Name = "duplicateCount";
			this.duplicateCount.Size = new System.Drawing.Size(156, 16);
			this.duplicateCount.TabIndex = 1;
			this.duplicateCount.Text = "0";
			// 
			// duplicateLabel
			// 
			this.duplicateLabel.AutoSize = true;
			this.duplicateLabel.Location = new System.Drawing.Point(3, 32);
			this.duplicateLabel.Name = "duplicateLabel";
			this.duplicateLabel.Size = new System.Drawing.Size(60, 13);
			this.duplicateLabel.TabIndex = 0;
			this.duplicateLabel.Text = "Duplicates:";
			// 
			// resetButton
			// 
			this.resetButton.Enabled = false;
			this.resetButton.Location = new System.Drawing.Point(103, 385);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(85, 23);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
			// 
			// optionsGroup
			// 
			this.optionsGroup.Controls.Add(this.validatePack);
			this.optionsGroup.Controls.Add(this.fileNameLimit);
			this.optionsGroup.Controls.Add(this.neatFilePaths);
			this.optionsGroup.Location = new System.Drawing.Point(633, 206);
			this.optionsGroup.Name = "optionsGroup";
			this.optionsGroup.Size = new System.Drawing.Size(231, 91);
			this.optionsGroup.TabIndex = 9;
			this.optionsGroup.TabStop = false;
			this.optionsGroup.Text = "Options";
			// 
			// validatePack
			// 
			this.validatePack.AutoSize = true;
			this.validatePack.Checked = true;
			this.validatePack.CheckState = System.Windows.Forms.CheckState.Checked;
			this.validatePack.Location = new System.Drawing.Point(9, 68);
			this.validatePack.Name = "validatePack";
			this.validatePack.Size = new System.Drawing.Size(91, 17);
			this.validatePack.TabIndex = 2;
			this.validatePack.Text = "Validate pack";
			this.validatePack.UseVisualStyleBackColor = true;
			// 
			// fileNameLimit
			// 
			this.fileNameLimit.AutoSize = true;
			this.fileNameLimit.Checked = true;
			this.fileNameLimit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.fileNameLimit.Location = new System.Drawing.Point(9, 45);
			this.fileNameLimit.Name = "fileNameLimit";
			this.fileNameLimit.Size = new System.Drawing.Size(129, 17);
			this.fileNameLimit.TabIndex = 1;
			this.fileNameLimit.Text = "Limit to same filename";
			this.fileNameLimit.UseVisualStyleBackColor = true;
			// 
			// neatFilePaths
			// 
			this.neatFilePaths.AutoSize = true;
			this.neatFilePaths.Checked = true;
			this.neatFilePaths.CheckState = System.Windows.Forms.CheckState.Checked;
			this.neatFilePaths.Location = new System.Drawing.Point(9, 22);
			this.neatFilePaths.Name = "neatFilePaths";
			this.neatFilePaths.Size = new System.Drawing.Size(98, 17);
			this.neatFilePaths.TabIndex = 0;
			this.neatFilePaths.Text = "Neat File Paths";
			this.neatFilePaths.UseVisualStyleBackColor = true;
			// 
			// packTwoNameTextbox
			// 
			this.packTwoNameTextbox.Location = new System.Drawing.Point(477, 35);
			this.packTwoNameTextbox.Name = "packTwoNameTextbox";
			this.packTwoNameTextbox.Size = new System.Drawing.Size(150, 20);
			this.packTwoNameTextbox.TabIndex = 15;
			// 
			// packOneNameTextbox
			// 
			this.packOneNameTextbox.Location = new System.Drawing.Point(477, 10);
			this.packOneNameTextbox.Name = "packOneNameTextbox";
			this.packOneNameTextbox.Size = new System.Drawing.Size(150, 20);
			this.packOneNameTextbox.TabIndex = 14;
			// 
			// p2NameLabel
			// 
			this.p2NameLabel.AutoSize = true;
			this.p2NameLabel.Location = new System.Drawing.Point(433, 38);
			this.p2NameLabel.Name = "p2NameLabel";
			this.p2NameLabel.Size = new System.Drawing.Size(38, 13);
			this.p2NameLabel.TabIndex = 13;
			this.p2NameLabel.Text = "Name:";
			// 
			// p1NameLabel
			// 
			this.p1NameLabel.AutoSize = true;
			this.p1NameLabel.Location = new System.Drawing.Point(433, 13);
			this.p1NameLabel.Name = "p1NameLabel";
			this.p1NameLabel.Size = new System.Drawing.Size(41, 13);
			this.p1NameLabel.TabIndex = 12;
			this.p1NameLabel.Text = "Name: ";
			// 
			// complexCheck
			// 
			this.complexCheck.AutoSize = true;
			this.complexCheck.Location = new System.Drawing.Point(9, 22);
			this.complexCheck.Name = "complexCheck";
			this.complexCheck.Size = new System.Drawing.Size(129, 17);
			this.complexCheck.TabIndex = 3;
			this.complexCheck.Text = "Similar textures check";
			this.complexCheck.UseVisualStyleBackColor = true;
			// 
			// advancedGroup
			// 
			this.advancedGroup.Controls.Add(this.hideFullMatches);
			this.advancedGroup.Controls.Add(this.perLabel);
			this.advancedGroup.Controls.Add(this.percentInput);
			this.advancedGroup.Controls.Add(this.minPerLabel);
			this.advancedGroup.Controls.Add(this.complexCheck);
			this.advancedGroup.Location = new System.Drawing.Point(633, 303);
			this.advancedGroup.Name = "advancedGroup";
			this.advancedGroup.Size = new System.Drawing.Size(231, 105);
			this.advancedGroup.TabIndex = 16;
			this.advancedGroup.TabStop = false;
			this.advancedGroup.Text = "Advanced";
			// 
			// minPerLabel
			// 
			this.minPerLabel.AutoSize = true;
			this.minPerLabel.Location = new System.Drawing.Point(6, 42);
			this.minPerLabel.Name = "minPerLabel";
			this.minPerLabel.Size = new System.Drawing.Size(51, 13);
			this.minPerLabel.TabIndex = 5;
			this.minPerLabel.Text = "Minimum:";
			// 
			// percentInput
			// 
			this.percentInput.Location = new System.Drawing.Point(59, 38);
			this.percentInput.Name = "percentInput";
			this.percentInput.Size = new System.Drawing.Size(44, 20);
			this.percentInput.TabIndex = 6;
			this.percentInput.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
			// 
			// perLabel
			// 
			this.perLabel.AutoSize = true;
			this.perLabel.Location = new System.Drawing.Point(106, 42);
			this.perLabel.Name = "perLabel";
			this.perLabel.Size = new System.Drawing.Size(15, 13);
			this.perLabel.TabIndex = 7;
			this.perLabel.Text = "%";
			// 
			// hideFullMatches
			// 
			this.hideFullMatches.AutoSize = true;
			this.hideFullMatches.Location = new System.Drawing.Point(9, 64);
			this.hideFullMatches.Name = "hideFullMatches";
			this.hideFullMatches.Size = new System.Drawing.Size(120, 17);
			this.hideFullMatches.TabIndex = 8;
			this.hideFullMatches.Text = "Hide 100% matches";
			this.hideFullMatches.UseVisualStyleBackColor = true;
			// 
			// UI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 417);
			this.Controls.Add(this.advancedGroup);
			this.Controls.Add(this.packTwoNameTextbox);
			this.Controls.Add(this.packOneNameTextbox);
			this.Controls.Add(this.p2NameLabel);
			this.Controls.Add(this.p1NameLabel);
			this.Controls.Add(this.optionsGroup);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.searchButton);
			this.Controls.Add(this.exportButton);
			this.Controls.Add(this.outputTextBox);
			this.Controls.Add(this.packTwoPath);
			this.Controls.Add(this.packOnePath);
			this.Controls.Add(this.packTwoLabel);
			this.Controls.Add(this.packOneLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "UI";
			this.Text = "Duplicate Texture Finder";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.optionsGroup.ResumeLayout(false);
			this.optionsGroup.PerformLayout();
			this.advancedGroup.ResumeLayout(false);
			this.advancedGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.percentInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label packOneLabel;
        private System.Windows.Forms.Label packTwoLabel;
        private System.Windows.Forms.TextBox packOnePath;
        private System.Windows.Forms.TextBox packTwoPath;
        private System.Windows.Forms.RichTextBox outputTextBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label duplicateCount;
        private System.Windows.Forms.Label duplicateLabel;
        private System.Windows.Forms.RichTextBox perfTimeLog;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label perfStatsLabel;
        private System.Windows.Forms.GroupBox optionsGroup;
        private System.Windows.Forms.CheckBox neatFilePaths;
        private System.Windows.Forms.TextBox packTwoNameTextbox;
        private System.Windows.Forms.TextBox packOneNameTextbox;
        private System.Windows.Forms.Label p2NameLabel;
        private System.Windows.Forms.Label p1NameLabel;
        private System.Windows.Forms.CheckBox fileNameLimit;
		private System.Windows.Forms.CheckBox validatePack;
		private System.Windows.Forms.CheckBox complexCheck;
		private System.Windows.Forms.GroupBox advancedGroup;
		private System.Windows.Forms.Label minPerLabel;
		private System.Windows.Forms.NumericUpDown percentInput;
		private System.Windows.Forms.Label perLabel;
		private System.Windows.Forms.CheckBox hideFullMatches;
	}
}

