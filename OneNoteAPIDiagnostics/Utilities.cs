using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public class Utilities
    {
        public static async Task<Dictionary<Guid, SharePointList>> RetrieveSharePointLists(string url, string user, string password, bool allLists)
        {
            Dictionary<Guid, SharePointList> listDict = new Dictionary<Guid, SharePointList>();
            using (CsomProxy csomProxy = new CsomProxy(url, user, password))
            {
                if (allLists)
                {
                    List<SharePointList> lists = await csomProxy.GetListsAsyc();
                    foreach (var list in lists)
                    {
                        listDict.Add(list.Id, list);
                    }
                }
                else
                {
                    var list = await csomProxy.GetDefaultDocumentLibraryAsyc();
                    listDict.Add(list.Id, list);
                }
            }

            return listDict;
        }

        /// <summary>
        /// Processing SharePoint list to add Logs to collection
        /// </summary>
        /// <param name="lists"> SharePoint list collection</param>
        /// <returns> task object</returns>
        public static string CreateLogText(Dictionary<Guid, SharePointList> listDict)
		{
            StringBuilder sb = new StringBuilder();
            bool isMultiple = listDict.Keys.Count > 1;
            foreach (var dictItem in listDict)
            {
                if (isMultiple)
                {
                    sb.Append("Title: ");
                    sb.Append(dictItem.Value.Title);
                    sb.Append("\r\n");
                }

                sb.Append("Url: ");
                sb.Append(dictItem.Value.HostUrl + dictItem.Value.RootFolder.Path);
                sb.Append("\r\n");

                sb.Append("Item Count: ");
                sb.Append(dictItem.Value.ListItemCount);
                sb.Append("\r\n");

                sb.Append("Notebook Count: ");
                sb.Append(dictItem.Value.NotebookCount);
                sb.Append("\r\n");

                sb.Append("Folder Count: ");
                sb.Append(dictItem.Value.FolderCount);
                sb.Append("\r\n");

                sb.Append("Section Count: ");
                sb.Append(dictItem.Value.SectionCount);
                sb.Append("\r\n");

                sb.Append("Html File Type: ");
                sb.Append(dictItem.Value.HtmlFileTypeIndexed);
                sb.Append("\r\n");

                sb.Append("Content Type Id: ");
                sb.Append(dictItem.Value.ContentTypeIdIndexed);
                sb.Append("\r\n");

                sb.Append("File Type: ");
                sb.Append(dictItem.Value.FileTypeIndexed);
                sb.Append("\r\n");

                if (isMultiple)
                {
                    sb.Append("-------------------------------------------\r\n");
                }                
            }

            return sb.ToString();
		}

		/// <summary>
		/// Adding Logs to file system. It suppresses the exception
		/// </summary>
		/// <param name="logInfo"> Log info text</param>
		public static void AddToLogFile(string logInfo)
		{
			try
			{
				var path = System.Environment.CurrentDirectory + "\\Logs";
				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(path);
				}

				using (var stream = System.IO.File.CreateText(path + "\\log.txt"))
				{
					stream.Write(logInfo);
				}
			}
			catch
			{
				// Supressing I/O exceptions
			}
		}

        public static string UserPrompt(string diaLogHeader, string dialogText)
        {
            Form userPrompt = new Form()
            {
                Width = 400,
                Height = 150,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.Fixed3D,               
                Text = diaLogHeader,
            
            };

            Label label = new Label() { Left = 23, Top = 20, Width=200, Text = dialogText };
            userPrompt.Controls.Add(label);
            
            TextBox userInputTextBox = new TextBox() { Left = 25, Top = 45, Width = 350 };
            userPrompt.Controls.Add(userInputTextBox);

            Button okButton = new Button() { Text = "Ok", Left = 25, Width = 50, Top = 75, DialogResult = DialogResult.OK };
            okButton.Click += (sender, e) => 
            {
                if (!string.IsNullOrWhiteSpace(userInputTextBox.Text))
                {
                    userPrompt.Close();
                }
            };  
                      
            userPrompt.Controls.Add(okButton);            
            userPrompt.AcceptButton = okButton;
            return userPrompt.ShowDialog() == DialogResult.OK ? userInputTextBox.Text : "";
        }

        public static Form ProcessingDialog()
        {
            Form processingDialog = new Form()
            {
                Width = 100,
                Height = 100,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog      
            };

            Label label = new Label() { Left = 30, Top = 15, Text = "Processing..." };
            processingDialog.Controls.Add(label);

            return processingDialog;
        }
    }
}
