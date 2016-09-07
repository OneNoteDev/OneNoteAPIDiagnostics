namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	partial class Menu
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.personalSiteMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.siteCollectionMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalSiteMenu,
            this.siteCollectionMenu});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(926, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// personalSiteMenu
			// 
			this.personalSiteMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.personalSiteMenu.Name = "personalSiteMenu";
			this.personalSiteMenu.Size = new System.Drawing.Size(91, 20);
			this.personalSiteMenu.Text = "Personal Site";
			this.personalSiteMenu.Click += new System.EventHandler(this.personalSiteMenu_Click);
			// 
			// siteCollectionMenu
			// 
			this.siteCollectionMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.siteCollectionMenu.Name = "siteCollectionMenu";
			this.siteCollectionMenu.Size = new System.Drawing.Size(99, 20);
			this.siteCollectionMenu.Text = "Site Collection";
			this.siteCollectionMenu.Click += new System.EventHandler(this.siteCollectionMenu_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.menuStrip1);
			this.Name = "Menu";
			this.Size = new System.Drawing.Size(926, 28);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem personalSiteMenu;
		private System.Windows.Forms.ToolStripMenuItem siteCollectionMenu;
	}
}
