using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{    
    public class LogEntry
    {
        public string ListTile;
        public bool FileTypeIndexed;
        public bool HtmlFileTypeIndexed;
    }

    public class Folder
    {
        public string Path;
        public int NotebookCount;
        public int FolderCount;

        public Folder(string path, int depth)
        {
            Path = path;
            Folders = new FolderCollection(depth);
            Files = new List<File>();
        }
                
        public FolderCollection Folders;
        public List<File> Files;
    }

    public class File
    {
        public int SectionCount;
    }

    public class FolderCollection
    {
        public int Depth;
        public List<Folder> Folders;
        public FolderCollection(int depth)
        {
            Depth = depth;
            Folders = new List<Folder>();
        }

        public void Add(Folder folder)
        {
            Folders.Add(folder);
        }

        public static void InsertFolder(ListItem item, Folder root)
        {
            int depth = item.FieldValues["FileRef"].ToString().Split('/').Length;
            var parentPath = item["FileRef"].ToString().Substring(0, item["FileRef"].ToString().LastIndexOf("/"));
            FolderCollection folders = FindFolderCollection(root, depth);
            Folder parentFolder = null;
            if (folders == null)
            {
                FindNearesFolderCollection(root, ref folders, depth);

                if (folders != null)
                {
                    parentFolder = folders.Folders.FirstOrDefault(f => item.FieldValues["FileRef"].ToString().StartsWith(f.Path));
                    string pathDiff = parentPath.Replace(parentFolder.Path, string.Empty);
                    string[] paths = pathDiff.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string path in paths)
                    {
                        Folder childFolder = new Folder(parentFolder.Path + "/" + path, parentFolder.Folders.Depth + 1);
                        parentFolder.Folders.Add(childFolder);
                        parentFolder = childFolder;
                    }


                }
            }
            else
            {
                parentFolder = folders.Folders.FirstOrDefault(f => item.FieldValues["FileRef"].ToString().StartsWith(f.Path));
            }

            if (parentFolder != null)
            {
                if (item["ContentTypeId"].ToString().StartsWith("0x00120"))
                {
                    Folder childFolder = new Folder(item["FileRef"].ToString(), parentFolder.Folders.Depth + 1);
                    parentFolder.Folders.Add(childFolder);
                    parentFolder = childFolder;
                }
                else
                {
                    File file = new File();
                    parentFolder.Files.Add(file);
                }   
            }
        }

        public static FolderCollection FindFolderCollection(Folder folder, int depth)
        {
            if (folder.Folders.Depth + 1 == depth)
            {
                return folder.Folders;
            }

            if (folder.Folders.Folders.Count > 0)
            {
                foreach (Folder f in folder.Folders.Folders)
                {
                    var folders = FindFolderCollection(f, depth);
                    if (folders != null)
                    {
                        return folders;
                    }
                }
            }            

            return null;
        }

        public static void FindNearesFolderCollection(Folder root, ref FolderCollection folders, int depth)
        {
            if (root.Folders.Depth < depth)
            {
                if (folders == null)
                {
                    folders = root.Folders;
                }
                else if (folders.Depth < root.Folders.Depth)
                {
                    folders = root.Folders;
                }
            }

            if (root.Folders.Folders.Count > 0)
            {
                foreach (Folder folder in root.Folders.Folders)
                {
                    FindNearesFolderCollection(folder, ref folders, depth);
                }
            }
        }
    }   
}
