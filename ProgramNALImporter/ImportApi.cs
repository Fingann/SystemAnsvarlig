using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramNALImporter
{
    using System.IO;

    public class ImportApi
    {

        struct ITProgram
        {
            string Name;

            string Admin;

            string Description;

            public ITProgram(string name, string admin, string description)
            {
                this.Name = name;
                this.Admin = admin;
                this.Description = description;

            }
        }

        public string Url { get; set; } = "http://bkk-web.bkk.no:86/idaweb?dokid=10544343&filename=IDA-dokument.xls";

        public ImportApi(string url)
        {
            Url = url;
        }

        public List<ISystem> GetSystems()
        {
            List<ISystem> systemList;
            using (var filestream = new FileDownloader().DownloadFile(this.Url))
            {

                systemList = new ExcelReader().GenerateSystemList(filestream);
            }

            return systemList;
        }


    }
}
