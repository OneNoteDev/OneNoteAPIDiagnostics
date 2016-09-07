using System;
using Generic = System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public partial class SiteCollectionForm : System.Windows.Forms.Form
	{
		public SiteCollectionForm()
		{
			InitializeComponent();
		}

		private async void GetInfoButton_Click(object sender, EventArgs e)
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
					Generic.List<List> lists = null;
					if (rdoAllList.Checked)
					{
						lists = await utilities.GetLists();
						listBox.Enabled = true;
						listBox.Items.Clear();
						listBox.Enabled = false;
					}
					else
					{
						var list = await utilities.GetDocumentLibrary();
						lists = new Generic.List<List>() { list };
					}


					lists.ForEach(l => listBox.Items.Add(l.Title));

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

		private async void BuildIndexButton_Click(object sender, EventArgs e)
		{
			if (!ValidateParameters())
			{
				return;
			}

			if (listBox.SelectedItem == null)
			{
				MessageBox.Show("Select List");
				listBox.Focus();
				return;
			}
			try
			{
				DisabledControls();
				using (Utilities utilities = new Utilities(UrlText.Text, UserText.Text, PasswordText.Text))
				{
					var lib = await utilities.GetListByTitle(listBox.SelectedItem.ToString());
					await utilities.AddIndexOnListFields(lib);
					lib = await utilities.GetListByTitle(listBox.SelectedItem.ToString());
					Generic.List<List> lists = new Generic.List<List>() { lib };
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
			listBox.Enabled = false;

		}

		private void EnabledControls()
		{
			UrlText.Enabled = true;
			UserText.Enabled = true;
			PasswordText.Enabled = true;
			GetInfoButton.Enabled = true;
			BuildIndexButton.Enabled = true;
			listBox.Enabled = true;
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

		private void PasswordText_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
