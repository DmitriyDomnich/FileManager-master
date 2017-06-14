using System;
using System.IO;
using System.Threading.Tasks;


namespace FileManager
{
    class Paste : Form1
    {
        string paste;
        string globalPath;
        string copy;
        string curPath;
        public string message;
        public async Task<string> Pasted(string paste, string globalPath, string copy, string curPath, string cutOrCopy)
        {
            string message;
            this.paste = paste;
            this.globalPath = globalPath;
            this.copy = copy;
            this.curPath = curPath;
            if (cutOrCopy == "Copy")
            {
                return message =await CopyToPath(this.copy, this.paste);
            } else
            {
                return message = await CutToPath(this.paste, this.globalPath, this.copy, this.curPath);
            }        
        }

        public async Task<string> CutToPath(string paste, string globalPath, string copy, string curPath)
        {
            try
            {
                this.paste = globalPath + "//" + paste;

                try
                {
                    File.Move(copy, this.paste + "//" + curPath);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return message;
                }

            }
            catch
            {
              return message = await CutPasteDir(paste, this.paste);
            }
            return "";
        }
      
        private async Task<string> CopyToPath(string copyPath, string paste)
        {
            string message;
            try
            {
                this.paste = globalPath + "//" + paste;
                bool flag = false;
                int numberOfCopies = 0;
                while (!flag)
                {
                    try
                    {
                        File.Copy(copyPath, this.paste + "//" + curPath);
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        if (curPath.Contains("("))
                        {
                            var arr = curPath.Split('(', ')');
                            curPath = null;
                            curPath = arr[0] + $"({++numberOfCopies})" + arr[2];


                        } else
                        {
                            var t = curPath.Split('.');
                            curPath = t[0] + $"({++numberOfCopies})" + "." + t[1];
                        }
                    }
                }
            }
            catch
            {
               return message = await CopyPasteDir(copyPath, this.paste);
            }
            return "";
        }

        private async Task<string> CopyPasteDir(string copyPath, string paste)
        {
            string message;
            try
            {
                DirectoryInfo sourceDir = new DirectoryInfo(copyPath);
                DirectoryInfo targetDir = new DirectoryInfo(paste);
                CopyAll(sourceDir, targetDir);
            } 
            catch (Exception ex)
            {
                return message = ex.Message;
            }
            return "";
        }

        private async Task<string> CutPasteDir(string copyPath, string paste)
        {
            string message;
            try
            {
                DirectoryInfo sourceDir = new DirectoryInfo(copyPath);
                DirectoryInfo targetDir = new DirectoryInfo(paste);
                CutAll(sourceDir, targetDir);
            }
            catch (Exception ex)
            {
                return message = ex.Message;
            }
            return "";
        }

        private void CutAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                var newDirectoryInfo = target.CreateSubdirectory(source.Name);
                foreach (var fileInfo in source.GetFiles())
                    fileInfo.MoveTo(Path.Combine(newDirectoryInfo.FullName, fileInfo.Name));

                foreach (var childDirectoryInfo in source.GetDirectories())
                    CutAll(childDirectoryInfo, newDirectoryInfo);
            }
            catch (Exception ex) { }
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            var newDirectoryInfo = target.CreateSubdirectory(source.Name);
            foreach (var fileInfo in source.GetFiles())
                fileInfo.CopyTo(Path.Combine(newDirectoryInfo.FullName, fileInfo.Name));

            foreach (var childDirectoryInfo in source.GetDirectories())
                CopyAll(childDirectoryInfo, newDirectoryInfo);
        }
    }
}
