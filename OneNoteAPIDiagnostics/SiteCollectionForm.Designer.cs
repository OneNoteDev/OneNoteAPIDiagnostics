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
            this.viewButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.UserText = new System.Windows.Forms.TextBox();
            this.UrlText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ComboBox();
            this.viewHierarchy = new System.Windows.Forms.Button();
            this.moveNotebooks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(403, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "user@tenant.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(41, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Result";
            // 
            // ResultText
            // 
            this.ResultText.Location = new System.Drawing.Point(44, 174);
            this.ResultText.Multiline = true;
            this.ResultText.Name = "ResultText";
            this.ResultText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ResultText.Size = new System.Drawing.Size(450, 276);
            this.ResultText.TabIndex = 23;
            // 
            // BuildIndexButton
            // 
            this.BuildIndexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.BuildIndexButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BuildIndexButton.Location = new System.Drawing.Point(347, 472);
            this.BuildIndexButton.Name = "BuildIndexButton";
            this.BuildIndexButton.Size = new System.Drawing.Size(118, 23);
            this.BuildIndexButton.TabIndex = 22;
            this.BuildIndexButton.Text = "Build Index";
            this.BuildIndexButton.UseVisualStyleBackColor = true;
            this.BuildIndexButton.Click += new System.EventHandler(this.BuildIndexButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.viewButton.Location = new System.Drawing.Point(129, 114);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 21;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(41, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(41, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(37, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "SharePoint Url";
            // 
            // PasswordText
            // 
            this.PasswordText.Location = new System.Drawing.Point(129, 84);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.PasswordChar = '*';
            this.PasswordText.Size = new System.Drawing.Size(255, 20);
            this.PasswordText.TabIndex = 17;
            this.PasswordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
            // 
            // UserText
            // 
            this.UserText.Location = new System.Drawing.Point(129, 49);
            this.UserText.Name = "UserText";
            this.UserText.Size = new System.Drawing.Size(255, 20);
            this.UserText.TabIndex = 16;
            this.UserText.TextChanged += new System.EventHandler(this.UserText_TextChanged);
            // 
            // UrlText
            // 
            this.UrlText.Location = new System.Drawing.Point(129, 17);
            this.UrlText.Name = "UrlText";
            this.UrlText.Size = new System.Drawing.Size(336, 20);
            this.UrlText.TabIndex = 15;
            this.UrlText.TextChanged += new System.EventHandler(this.UrlText_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(41, 477);
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
            this.listBox.Location = new System.Drawing.Point(111, 473);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(227, 21);
            this.listBox.TabIndex = 32;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // viewHierarchy
            // 
            this.viewHierarchy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.viewHierarchy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.viewHierarchy.Location = new System.Drawing.Point(211, 114);
            this.viewHierarchy.Name = "viewHierarchy";
            this.viewHierarchy.Size = new System.Drawing.Size(102, 23);
            this.viewHierarchy.TabIndex = 35;
            this.viewHierarchy.Text = "View Hierarchy";
            this.viewHierarchy.UseVisualStyleBackColor = true;
            this.viewHierarchy.Click += new System.EventHandler(this.ViewHierarchy_Click);
            // 
            // moveNotebooks
            // 
            this.moveNotebooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.moveNotebooks.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.moveNotebooks.Location = new System.Drawing.Point(320, 114);
            this.moveNotebooks.Name = "moveNotebooks";
            this.moveNotebooks.Size = new System.Drawing.Size(142, 23);
            this.moveNotebooks.TabIndex = 36;
            this.moveNotebooks.Text = "Move Notebooks";
            this.moveNotebooks.UseVisualStyleBackColor = true;
            this.moveNotebooks.Click += new System.EventHandler(this.MoveNotebooks_Click);
            // 
            // SiteCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.moveNotebooks);
            this.Controls.Add(this.viewHierarchy);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ResultText);
            this.Controls.Add(this.BuildIndexButton);
            this.Controls.Add(this.viewButton);
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
            this.Load += new System.EventHandler(this.SiteCollectionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox ResultText;
		private System.Windows.Forms.Button BuildIndexButton;
		private System.Windows.Forms.Button viewButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PasswordText;
		private System.Windows.Forms.TextBox UserText;
		private System.Windows.Forms.TextBox UrlText;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox listBox;
        private System.Windows.Forms.Button viewHierarchy;
        private System.Windows.Forms.Button moveNotebooks;
    }
}