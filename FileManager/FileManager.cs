using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{

    public partial class Form1 : Form
    {
        protected string GlobalPathForFirstView;
        protected string CurrentPathForFirstView;
        protected string GlobalPathForSecondView;
        protected string CurrentPathForSecondView;
        int viewFirstFlag;
        int viewSecondFlag;
        string copyPath;
        string cutOrCopy;
        string deletePath;
        string cur;
        protected int LastActions;

        public Form1()
        {
            InitializeComponent();
            GetDrivesInizialize();
        }

        private void GetDrivesInizialize()
        {
            ViewOne.Items.Clear();
            foreach (DriveInfo di in DriveInfo.GetDrives())
                ViewOne.Items.Add(di.Name);
            ViewTwo.Items.Clear();
            foreach (DriveInfo di in DriveInfo.GetDrives())
                ViewTwo.Items.Add(di.Name);
        }

        private void GetDrives(int lastActions)
        {
            if (lastActions == 1)
            {
                ViewOne.Items.Clear();
                foreach (DriveInfo di in DriveInfo.GetDrives())
                    ViewOne.Items.Add(di.Name);
            } else
            {
                ViewTwo.Items.Clear();
                foreach (DriveInfo di in DriveInfo.GetDrives())
                    ViewTwo.Items.Add(di.Name);
            }
        }

        private void bBack_Click(object sender, EventArgs e)
        {
            Back();
        }

        private void Back()
        {
            if (LastActions == 1)
            {
                if (GlobalPathForFirstView == null)
                    return;
                DirectoryInfo dr = new DirectoryInfo(GlobalPathForFirstView);
                if (GlobalPathForFirstView.Length < 4)
                {
                    GetDrives(LastActions);
                    GlobalPathForFirstView = null;

                } else
                {
                    GlobalPathForFirstView = dr.Parent.FullName;
                    textBoxForFirstView.Text = GlobalPathForFirstView;
                    GetDir(GlobalPathForFirstView, ViewOne, 1);
                }
            } else
            {
                if (GlobalPathForSecondView == null)
                    return;
                DirectoryInfo dr = new DirectoryInfo(GlobalPathForSecondView);
                if (GlobalPathForSecondView.Length < 4)
                {
                    GetDrives(LastActions);
                    GlobalPathForSecondView = null;

                } else
                {
                    GlobalPathForSecondView = dr.Parent.FullName;
                    textBoxForSecondView.Text = GlobalPathForSecondView;
                    GetDir(GlobalPathForSecondView, ViewTwo, 2);
                }
            }
        }

        public void GetDir(string path, ListView oneOrTwo, int oneOrTwoList)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            LastActions = oneOrTwoList;

            if (dir.Exists)
            {
                oneOrTwo.Items.Clear();

                try
                {
                    foreach (var directory in dir.GetDirectories())
                    {
                        item = new ListViewItem(directory.Name, 0);
                        subItems = new ListViewItem.ListViewSubItem[]
                        {
                            new ListViewItem.ListViewSubItem(item,"<DIR>"),
                            new ListViewItem.ListViewSubItem(item,
                            directory.LastAccessTime.ToShortDateString())};
                        item.SubItems.AddRange(subItems);
                        oneOrTwo.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(ex.Message);
                }

                try
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        item = new ListViewItem(file.Name, 1);
                        subItems = new ListViewItem.ListViewSubItem[]
                            { new ListViewItem.ListViewSubItem(item, WriteSize(file)),
                     new ListViewItem.ListViewSubItem(item,
                        file.LastAccessTime.ToShortDateString())};
                        item.SubItems.AddRange(subItems);
                        oneOrTwo.Items.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(ex.Message);
                }
            } else
            {
                if (oneOrTwoList == 1)
                {
                    GlobalPathForFirstView = CurrentPathForFirstView;
                    return;
                } else
                {
                    GlobalPathForSecondView = CurrentPathForSecondView;
                    return;
                }
            }
        }


        public string WriteSize(FileInfo fInf)
        {
            string sLen = fInf.Length.ToString();
            if (fInf.Length >= (1 << 30))
                return sLen = string.Format("{0}Gb", fInf.Length >> 30);
            else
            if (fInf.Length >= (1 << 20))
                return sLen = string.Format("{0}Mb", fInf.Length >> 20);
            else
            if (fInf.Length >= (1 << 10))
                return sLen = string.Format("{0}Kb", fInf.Length >> 10);
            return "sg";
        }

        private void ViewOne_DoubleClick(object sender, EventArgs e)
        {
            if (GlobalPathForFirstView == null)
            {
                CurrentPathForFirstView = GlobalPathForFirstView;
                GlobalPathForFirstView = GlobalPathForFirstView + ViewOne.SelectedItems[0].Text;
                textBoxForFirstView.Text = GlobalPathForFirstView;
            } else
            {
                CurrentPathForFirstView = GlobalPathForFirstView;
                GlobalPathForFirstView = GlobalPathForFirstView + "\\" + ViewOne.SelectedItems[0].Text;
                textBoxForFirstView.Text = GlobalPathForFirstView;
            }

            GetDir(GlobalPathForFirstView, ViewOne, 1);
        }

        private void ViewTwo_DoubleClick(object sender, EventArgs e)
        {
            if (GlobalPathForSecondView == null)
            {
                CurrentPathForSecondView = GlobalPathForSecondView;
                GlobalPathForSecondView = GlobalPathForSecondView + ViewTwo.SelectedItems[0].Text;
                textBoxForSecondView.Text = GlobalPathForSecondView;
            } else
            {
                CurrentPathForSecondView = GlobalPathForSecondView;
                GlobalPathForSecondView = GlobalPathForSecondView + "\\" + ViewTwo.SelectedItems[0].Text;
                textBoxForSecondView.Text = GlobalPathForSecondView;
            }

            GetDir(GlobalPathForSecondView, ViewTwo, 2);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            cutOrCopy = "Copy";
            if (ViewOne.SelectedItems.Count != 0)
            {
                cur = ViewOne.SelectedItems[0].Text;
                copyPath = GlobalPathForFirstView + "//" + ViewOne.SelectedItems[0].Text;
                viewFirstFlag = 1;

            } else
            {
                cur = ViewTwo.SelectedItems[0].Text;
                copyPath = GlobalPathForSecondView + "//" + ViewTwo.SelectedItems[0].Text;
                viewSecondFlag = 1;
            }
        }

        public void SetText(string text)
        {
            listBox1.Items.Add(text);
        }

        private async void bPaste_Click(object sender, EventArgs e)
        {
            string message = "";
            if (ViewOne.SelectedItems.Count != 0 && ViewTwo.SelectedItems.Count != 0 && viewFirstFlag != 0)
            {
                string stringCurCopy = copyPath;
                string stringPaste = ViewTwo.SelectedItems[0].Text;
                Paste pasteinstance = new Paste();
                message = await pasteinstance.Pasted(stringPaste, GlobalPathForSecondView, stringCurCopy, cur, cutOrCopy);
                listBox1.Items.Add(message);
            } else if (ViewOne.SelectedItems.Count != 0 && ViewTwo.SelectedItems.Count != 0 && viewSecondFlag != 0)
            {
                string stringCurCopy = copyPath;
                string stringPaste = ViewOne.SelectedItems[0].Text;
                Paste pasteinstance = new Paste();
                message = await pasteinstance.Pasted(stringPaste, GlobalPathForSecondView, stringCurCopy, cur, cutOrCopy);
                listBox1.Items.Add(message);

            } else if (ViewOne.SelectedItems.Count != 0 && ViewTwo.SelectedItems.Count == 0 && viewFirstFlag != 0)
            {
                string stringCurCopy = copyPath;
                string stringPaste = ViewOne.SelectedItems[0].Text;
                Paste pasteinstance = new Paste();
                message = await pasteinstance.Pasted(stringPaste, GlobalPathForSecondView, stringCurCopy, cur, cutOrCopy);
                listBox1.Items.Add(message);

            } else if (ViewOne.SelectedItems.Count == 0 && ViewTwo.SelectedItems.Count != 0 && viewSecondFlag != 0)
            {
                string stringCurCopy = copyPath;
                string stringPaste = ViewTwo.SelectedItems[0].Text;
                Paste pasteinstance = new Paste();
                message = await pasteinstance.Pasted(stringPaste, GlobalPathForSecondView, stringCurCopy, cur, cutOrCopy);
                listBox1.Items.Add(message);
            }
        }

        private void bProperties_Click(object sender, EventArgs e)
        {
            if (ViewOne.SelectedItems.Count != 0)
            {
                Properties(GlobalPathForFirstView + "//" + ViewOne.SelectedItems[0].Text, 1);
            } else
            {
                Properties(GlobalPathForSecondView + "//" + ViewTwo.SelectedItems[0].Text, 2);
            }
        }

        private void Properties(string path, int Id)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (Id == 1)
                {
                    listBoxForFirstView.Items.Clear();
                    listBoxForFirstView.Items.Add($"Full name {dir.FullName}");
                    string s = $"Creation time {dir.CreationTime.Year}-{dir.CreationTime.Month}-{dir.CreationTime.Day}-{dir.CreationTime.Hour}:{dir.CreationTime.Minute}:{dir.CreationTime.Second}";
                    listBoxForFirstView.Items.Add(s);
                    listBoxForFirstView.Items.Add($"Last change {dir.LastWriteTime}");
                    listBoxForFirstView.Items.Add($"Directories - { dir.GetDirectories().Length}");
                    listBoxForFirstView.Items.Add($"Files - { dir.GetFiles().Length}");
                } else
                {
                    listBoxForSecondView.Items.Clear();
                    listBoxForSecondView.Items.Add($"Full name {dir.FullName}");
                    string s = $"Creation time {dir.CreationTime.Year}-{dir.CreationTime.Month}-{dir.CreationTime.Day}-{dir.CreationTime.Hour}:{dir.CreationTime.Minute}:{dir.CreationTime.Second}";
                    listBoxForSecondView.Items.Add(s);
                    listBoxForSecondView.Items.Add($"Last change {dir.LastWriteTime}");
                    listBoxForSecondView.Items.Add($"Directories - { dir.GetDirectories().Length}");
                    listBoxForSecondView.Items.Add($"Files - { dir.GetFiles().Length}");
                }
            }
            catch (Exception) { }
        }

        private void bCut_Click(object sender, EventArgs e)
        {
            cutOrCopy = "Cut";
            if (ViewOne.SelectedItems.Count != 0)
            {
                cur = ViewOne.SelectedItems[0].Text;
                copyPath = GlobalPathForFirstView + "//" + ViewOne.SelectedItems[0].Text;
                viewFirstFlag = 1;

            } else
            {
                cur = ViewTwo.SelectedItems[0].Text;
                copyPath = GlobalPathForSecondView + "//" + ViewTwo.SelectedItems[0].Text;
                viewSecondFlag = 1;
            }
        }

        private async void bDelete_Click(object sender, EventArgs e)
        {            
            Delete delete = new Delete();
            if (ViewOne.SelectedItems.Count != 0)
            {
                cur = ViewOne.SelectedItems[0].Text;
                deletePath = GlobalPathForFirstView + "//" + ViewOne.SelectedItems[0].Text;
                viewFirstFlag = 1;
                listBox1.Items.Clear();
                listBox1.Items.Add (await delete.DeletedDirOrFiles(deletePath));

            } else
            {
                cur = ViewTwo.SelectedItems[0].Text;
                deletePath = GlobalPathForSecondView + "//" + ViewTwo.SelectedItems[0].Text;
                viewSecondFlag = 1;
                listBox1.Items.Clear();
                listBox1.Items.Add(await delete.DeletedDirOrFiles(deletePath));
            }
            
        }
    }
}
