using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramNALImporter
{
    using System.IO;
    using System.Net;

    class FileDownloader: IDisposable
    {
        private MemoryStream filestream;

        public MemoryStream DownloadFile(string url)
        {
            WebClient wc = new WebClient();
            filestream = new MemoryStream(
                    wc.DownloadData("http://bkk-web.bkk.no:86/idaweb?dokid=10544343&filename=IDA-dokument.xls"));

            return filestream;


        }

        public void Dispose()
        {
            filestream.Close();
        }
    }
}
