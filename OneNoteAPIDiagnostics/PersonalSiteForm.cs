using System;
using Generic = System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;
using System.Linq;
using Microsoft.SharePoint.Client;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public partial class PersonalSiteForm : Form
	{
		public PersonalSiteForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Retrieving log info for OneNote items
		/// </summary>
		/// <param name="sender"> Sender object</param>
		/// <param name="e"> Event argument</param>
		private async void button1_Click(object sender, EventArgs e)
		{
			if (!ValidateParameters())
			{
				return;
			}
			try
			{
				DisabledControls();
				using (Utilities utilities = new Utilities(UrlText.Text, UserText.Text, PasswordText.Text))
				{
					var list = await utilities.GetDocumentLibrary();
					Generic.List<List> lists = new Generic.List<List>() { list };
					await utilities.AddListsInfo(lists);
					StringBuilder sb = new StringBuilder();
					utilities.Logs.ForEach(result => sb.Append(result + "\r\n"));
					ResultText.Text = sb.ToString();
					utilities.AddToLogFile(ResultText.Text);
				}
			}
			catch (Exception ex)
			{
				ResultText.Text = ex.ToString();
			}
			finally
			{
				EnabledControls();
			}
		}

		/// <summary>
		/// Building index on "File Type" and "HTML File Type" fields for document library
		/// </summary>
		/// <param name="sender"> sender object</param>
		/// <param name="e"> event argument</param>
		private async void BuildIndexButton_Click(object sender, EventArgs e)
		{
			if (!ValidateParameters())
			{
				return;
			}

			try
			{
				DisabledControls();
				using (Utilities utilities = new Utilities(UrlText.Text, UserText.Text, PasswordText.Text))
				{
					var docLib = await utilities.GetDocumentLibrary();
					await utilities.AddIndexOnListFields(docLib);
					docLib = await utilities.GetDocumentLibrary();
					Generic.List<List> lists = new Generic.List<List>() { docLib };
					await utilities.AddListsInfo(lists);
					StringBuilder sb = new StringBuilder();
					utilities.Logs.ForEach(result => sb.Append(result + "\r\n"));
					ResultText.Text = sb.ToString();
					utilities.AddToLogFile(ResultText.Text);
				}
			}
			catch (Exception ex)
			{
				ResultText.Text = ex.ToString();
			}
			finally
			{
				EnabledControls();
			}
		}

		private void DisabledControls()
		{
			ResultText.Text = string.Empty;
			UrlText.Enabled = false;
			UserText.Enabled = false;
			PasswordText.Enabled = false;
			GetInfoButton.Enabled = false;
			BuildIndexButton.Enabled = false;

		}

		private void EnabledControls()
		{
			UrlText.Enabled = true;
			UserText.Enabled = true;
			PasswordText.Enabled = true;
			GetInfoButton.Enabled = true;
			BuildIndexButton.Enabled = true;
		}

		/// <summary>
		/// Validating user inputs
		/// </summary>
		private bool ValidateParameters()
		{
			if (string.IsNullOrWhiteSpace(UrlText.Text))
			{
				MessageBox.Show("Please enter SharePoint Url value.");
				UrlText.Focus();
				return false;
			}

			if (string.IsNullOrWhiteSpace(UserText.Text))
			{
				MessageBox.Show("Please enter User value.");
				UserText.Focus();
				return false;
			}

			if (string.IsNullOrWhiteSpace(PasswordText.Text))
			{
				MessageBox.Show("Please enter Password.");
				PasswordText.Focus();
				return false;
			}

			return true;
		}

	}
}
