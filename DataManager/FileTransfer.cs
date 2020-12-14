using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class FileTransfer
    {
        public void SendFile(DataManagerOptions dataOptions)
        {
            File.Move(Path.Combine(dataOptions.FileDirectory, "information" + DateTime.Now.ToString("MM/dd/yyyy")
                + ".xml"), Path.Combine(dataOptions.SourceDirectory, "information" +
                DateTime.Now.ToString("MM/dd/yyyy") + ".xml"));
        }
    }
}
