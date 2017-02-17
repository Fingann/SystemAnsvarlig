using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramNALImporter
{
    using System.Data;
    using System.IO;

    using Excel;

    class ExcelReader
    {
        public List<ISystem> GenerateSystemList(MemoryStream filestream)
        {
            var tempSystemList = new List<ISystem>();
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(filestream);

            DataSet result = excelReader.AsDataSet();
            var test = result.Tables[0].Columns[0].Table.Rows;
            for (int i = 4; i < test.Count; i++)
            {
                if (!string.IsNullOrWhiteSpace(test[i].ItemArray[0].ToString()))
                {
                    var tempSystem = new ITSystem();

                   tempSystem.Name = test[i].ItemArray[0].ToString();
                   foreach (var admin in test[i].ItemArray[1].ToString().Split('/'))
                   {
                       tempSystem.SysAdministrator.Add(admin);
                   }
                    tempSystem.Description = test[i].ItemArray[4].ToString();



                    tempSystemList.Add(tempSystem);

                }






                //6. Free resources (IExcelDataReader is IDisposable)
              
            
            }
            excelReader.Close();
            return tempSystemList;

        }
    }


}
