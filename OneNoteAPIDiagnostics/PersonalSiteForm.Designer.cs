using Microsoft.Office.OneNote;
namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	partial class PersonalSiteForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalSiteForm));
			this.UrlText = new System.Windows.Forms.TextBox();
			this.UserText = new System.Windows.Forms.TextBox();
			this.PasswordText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.GetInfoButton = new System.Windows.Forms.Button();
			this.BuildIndexButton = new System.Windows.Forms.Button();
			this.ResultText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.menu1 = new Microsoft.Office.OneNote.OneNoteAPIDiagnostics.Menu();
			this.SuspendLayout();
			// 
			// UrlText
			// 
			this.UrlText.Location = new System.Drawing.Point(133, 35);
			this.UrlText.Name = "UrlText";
			this.UrlText.Size = new System.Drawing.Size(336, 20);
			this.UrlText.TabIndex = 0;
			// 
			// UserText
			// 
			this.UserText.Location = new System.Drawing.Point(133, 67);
			this.UserText.Name = "UserText";
			this.UserText.Size = new System.Drawing.Size(255, 20);
			this.UserText.TabIndex = 1;
			// 
			// PasswordText
			// 
			this.PasswordText.Location = new System.Drawing.Point(133, 102);
			this.PasswordText.Name = "PasswordText";
			this.PasswordText.PasswordChar = '*';
			this.PasswordText.Size = new System.Drawing.Size(255, 20);
			this.PasswordText.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(41, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "SharePoint Url";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(45, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "User";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(45, 107);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Password";
			// 
			// GetInfoButton
			// 
			this.GetInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.GetInfoButton.Location = new System.Drawing.Point(133, 137);
			this.GetInfoButton.Name = "GetInfoButton";
			this.GetInfoButton.Size = new System.Drawing.Size(75, 23);
			this.GetInfoButton.TabIndex = 6;
			this.GetInfoButton.Text = "Get Info";
			this.GetInfoButton.UseVisualStyleBackColor = true;
			this.GetInfoButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// BuildIndexButton
			// 
			this.BuildIndexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BuildIndexButton.Location = new System.Drawing.Point(172, 375);
			this.BuildIndexButton.Name = "BuildIndexButton";
			this.BuildIndexButton.Size = new System.Drawing.Size(159, 23);
			this.BuildIndexButton.TabIndex = 7;
			this.BuildIndexButton.Text = "Build Index";
			this.BuildIndexButton.UseVisualStyleBackColor = true;
			this.BuildIndexButton.Click += new System.EventHandler(this.BuildIndexButton_Click);
			// 
			// ResultText
			// 
			this.ResultText.Location = new System.Drawing.Point(48, 186);
			this.ResultText.Multiline = true;
			this.ResultText.Name = "ResultText";
			this.ResultText.Size = new System.Drawing.Size(421, 168);
			this.ResultText.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(45, 164);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Result";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(407, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "user@tenant.com";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(50, 379);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(106, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Document Library";
			// 
			// menu1
			// 
			this.menu1.Location = new System.Drawing.Point(0, 0);
			this.menu1.Name = "menu1";
			this.menu1.Size = new System.Drawing.Size(539, 26);
			this.menu1.TabIndex = 14;
			// 
			// PersonalSiteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 441);
			this.Controls.Add(this.label6);
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
			this.Name = "PersonalSiteForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OneNote API Diagnostics";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox UrlText;
		private System.Windows.Forms.TextBox UserText;
		private System.Windows.Forms.TextBox PasswordText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button GetInfoButton;
		private System.Windows.Forms.Button BuildIndexButton;
		private System.Windows.Forms.TextBox ResultText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private Menu menu1;
		private System.Windows.Forms.Label label6;
	}
}

