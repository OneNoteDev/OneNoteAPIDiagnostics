using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public partial class Menu : UserControl
	{
		public Menu()
		{
			InitializeComponent();
		}

		private void personalSiteMenu_Click(object sender, EventArgs e)
		{
			PersonalSiteForm form = new PersonalSiteForm();
			form.Show();
			this.Parent.Hide();
		}

		private void siteCollectionMenu_Click(object sender, EventArgs e)
		{
			SiteCollectionForm form = new SiteCollectionForm();
			form.Show();
			this.Parent.Hide();
		}
	}
}
