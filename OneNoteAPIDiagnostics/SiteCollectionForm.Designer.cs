namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	partial class SiteCollectionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteCollectionForm));
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.ResultText = new System.Windows.Forms.TextBox();
			this.BuildIndexButton = new System.Windows.Forms.Button();
			this.GetInfoButton = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.PasswordText = new System.Windows.Forms.TextBox();
			this.UserText = new System.Windows.Forms.TextBox();
			this.UrlText = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.listBox = new System.Windows.Forms.ComboBox();
			this.rdoAllList = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.menu1 = new Microsoft.Office.OneNote.OneNoteAPIDiagnostics.Menu();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(403, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "user@tenant.com";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(42, 193);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Result";
			// 
			// ResultText
			// 
			this.ResultText.Location = new System.Drawing.Point(44, 215);
			this.ResultText.Multiline = true;
			this.ResultText.Name = "ResultText";
			this.ResultText.Size = new System.Drawing.Size(421, 180);
			this.ResultText.TabIndex = 23;
			// 
			// BuildIndexButton
			// 
			this.BuildIndexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BuildIndexButton.Location = new System.Drawing.Point(347, 406);
			this.BuildIndexButton.Name = "BuildIndexButton";
			this.BuildIndexButton.Size = new System.Drawing.Size(118, 23);
			this.BuildIndexButton.TabIndex = 22;
			this.BuildIndexButton.Text = "Build Index";
			this.BuildIndexButton.UseVisualStyleBackColor = true;
			this.BuildIndexButton.Click += new System.EventHandler(this.BuildIndexButton_Click);
			// 
			// GetInfoButton
			// 
			this.GetInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GetInfoButton.Location = new System.Drawing.Point(129, 168);
			this.GetInfoButton.Name = "GetInfoButton";
			this.GetInfoButton.Size = new System.Drawing.Size(75, 23);
			this.GetInfoButton.TabIndex = 21;
			this.GetInfoButton.Text = "Get Info";
			this.GetInfoButton.UseVisualStyleBackColor = true;
			this.GetInfoButton.Click += new System.EventHandler(this.GetInfoButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(41, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Password";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(41, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "User";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(37, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "SharePoint Url";
			// 
			// PasswordText
			// 
			this.PasswordText.Location = new System.Drawing.Point(129, 101);
			this.PasswordText.Name = "PasswordText";
			this.PasswordText.PasswordChar = '*';
			this.PasswordText.Size = new System.Drawing.Size(255, 20);
			this.PasswordText.TabIndex = 17;
			this.PasswordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
			// 
			// UserText
			// 
			this.UserText.Location = new System.Drawing.Point(129, 66);
			this.UserText.Name = "UserText";
			this.UserText.Size = new System.Drawing.Size(255, 20);
			this.UserText.TabIndex = 16;
			// 
			// UrlText
			// 
			this.UrlText.Location = new System.Drawing.Point(129, 34);
			this.UrlText.Name = "UrlText";
			this.UrlText.Size = new System.Drawing.Size(336, 20);
			this.UrlText.TabIndex = 15;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(41, 410);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 13);
			this.label7.TabIndex = 30;
			this.label7.Text = "Select List";
			// 
			// listBox
			// 
			this.listBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Select List"});
			this.listBox.FormattingEnabled = true;
			this.listBox.Location = new System.Drawing.Point(111, 407);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(227, 21);
			this.listBox.TabIndex = 32;
			// 
			// rdoAllList
			// 
			this.rdoAllList.AutoSize = true;
			this.rdoAllList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoAllList.Location = new System.Drawing.Point(128, 139);
			this.rdoAllList.Name = "rdoAllList";
			this.rdoAllList.Size = new System.Drawing.Size(63, 17);
			this.rdoAllList.TabIndex = 33;
			this.rdoAllList.Text = "All List";
			this.rdoAllList.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Checked = true;
			this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.radioButton2.Location = new System.Drawing.Point(202, 139);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(124, 17);
			this.radioButton2.TabIndex = 34;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Document Library";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// menu1
			// 
			this.menu1.Location = new System.Drawing.Point(0, 0);
			this.menu1.Name = "menu1";
			this.menu1.Size = new System.Drawing.Size(539, 26);
			this.menu1.TabIndex = 29;
			this.menu1.Visible = false;
			// 
			// SiteCollectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 441);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.rdoAllList);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.menu1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.ResultText);
			this.Controls.Add(this.BuildIndexButton);
			this.Controls.Add(this.GetInfoButton);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PasswordText);
			this.Controls.Add(this.UserText);
			this.Controls.Add(this.UrlText);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SiteCollectionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "API Diagnostics";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Menu menu1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox ResultText;
		private System.Windows.Forms.Button BuildIndexButton;
		private System.Windows.Forms.Button GetInfoButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PasswordText;
		private System.Windows.Forms.TextBox UserText;
		private System.Windows.Forms.TextBox UrlText;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox listBox;
		private System.Windows.Forms.RadioButton rdoAllList;
		private System.Windows.Forms.RadioButton radioButton2;
	}
}