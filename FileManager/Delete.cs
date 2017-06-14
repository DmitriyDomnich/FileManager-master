using System;
using System.IO;
using System.Threading.Tasks;

namespace FileManager
{
    class Delete : Form1
    {
        public async Task<string> DeletedDirOrFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            try
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    FileInfo file = new FileInfo(path);
                    file.Delete();
                }
                catch (Exception exx)
                {
                    return exx.Message;
                }
            }
            return "";
        }
    }
}
