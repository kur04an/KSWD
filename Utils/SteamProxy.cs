using KSWD.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSWD.Utils
{
    public class SteamProxy
    {
        public SteamProxy()
        {
            
        }
        public void DownloadItems(ItemList itemList)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "Steamcmd.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = $"steamcmd +force_install_dir {path} +login anonymous {GetCommandForItems(itemList)} +quit";
            Process.Start(startInfo);
            
        }
        private string GetCommandForItems(ItemList itemList)
        {
            string command = "";
            foreach(SteamItem item in itemList.Items)
            {
                command += $"+workshop_download_item {item.GameID} {item.ItemID} ";
            }
            return command;
        }

    }
}
