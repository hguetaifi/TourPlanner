using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TourPlanner.Helpers
{
    public class FileDialogueHandler
    {
        public static string GetFilePathForExport()
        {
            FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string filePath = Path.Combine(folderPath, "Exported_Tours.txt");
                return filePath;
            }
            return null;
        }
    }
}
