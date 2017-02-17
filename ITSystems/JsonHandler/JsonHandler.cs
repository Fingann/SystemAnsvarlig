namespace ITSystems.JsonHandler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using ITSystems.Model;

    using Newtonsoft.Json;

    internal class JsonHandler
    {

        private FileInfo PathToJson = new FileInfo(@"\\bkk.no\root\app\Oppsett\SystemAnsvarlig\Database.json");

        private FileInfo PathToJson2 =
            new FileInfo(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory) + @"\Resources\SystemFile.json");

        public List<ITSystem> LoadJson()
        {
            CheckFile();
            while (IsFileLocked(this.PathToJson))
            {
                Thread.Sleep(200);
            }
            var text = File.ReadAllText(this.PathToJson.FullName, Encoding.UTF8);
            var s = JsonConvert.DeserializeObject<List<ITSystem>>(text);
            return s ?? new List<ITSystem>();
        }

        public void SaveJson(List<ITSystem> listToSave)
        {
            CheckFile();
            while (IsFileLocked(this.PathToJson))
            {
                Thread.Sleep(200);
            }
            var json = JsonConvert.SerializeObject(listToSave);
            File.WriteAllText(this.PathToJson.FullName, json, Encoding.UTF8);
            //FileWriter.WriteToFile(
            //    this.PathToJson,
            //    JsonConvert.SerializeObject(listToSave, new BoolConverter()));

        }

        public void CheckFile()
        {
            if (this.PathToJson.Exists)
            {

                return;
            }

            using (var fs = this.PathToJson.Create())
            {

            }
            File.SetAttributes(this.PathToJson.FullName, FileAttributes.Normal);

        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null) stream.Close();
            }

            //file is not locked
            return false;
        }




    }
}

