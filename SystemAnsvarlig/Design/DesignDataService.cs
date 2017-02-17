namespace SystemAnsvarlig.Design
{
    using System;
    using System.Collections.Generic;

    using SystemAnsvarlig.Model;

    using ITSystems.Model;

    public class DesignDataService : IDataService
    {
       

        public void GetSystems(Action<List<ITSystem>, Exception> callback)
        {
           
        }

        public void SetSystems(Action<bool, Exception> callback, List<ITSystem> listToSave)
        {
            throw new NotImplementedException();
        }

        public void Get(Action<List<ITSystem>, Exception> callback)
        {
            callback(
               new List<ITSystem>
                           {new ITSystem("wiki","appl_Wiki",new List<string> { "confluence" },new List<string> { "Sondre Fingann", "Geir Ove Nordtveit" },"Lisensbelagt per organisasjon",true, "1150","AD")
                ,
                               new ITSystem
                                   {
                                       Appl = "appl_ks",
                                       Alias = new List<string> { "Kundefront", "ks nasjonal" },
                                       SysAdministrator = new List<string> { "Unni", "Helge" },
                                       Name = "Kundefront",
                                       Description = "Lisensbelagt per organisasjon",
                                       LastUpdated = DateTime.Now,
                                       Lisens = true,
                                       Price = "200",
                                       Password = "AD"
                                   },
                               new ITSystem
                                   {
                                       Appl = "appl_Customer",
                                       Alias = new List<string> { "Customer", "customer Nasjonal" },
                                       SysAdministrator = new List<string> { "Sondre Fingann", "Geir Ove Nordtveit" },
                                       Name = "Wiki",
                                       Description = "Lisensbelagt per organisasjon",
                                       LastUpdated = DateTime.Now,
                                       Lisens = true,
                                       Price = "600",
                                       Password = "AD"
                                   }
                           }
         ,
               null);
        }

        public void Delete(Action<bool, Exception> callback, ITSystem listToSave)
        {
            throw new NotImplementedException();
        }

        public void Insert(Action<bool, Exception> callback, ITSystem listToSave)
        {
            throw new NotImplementedException();
        }

        public void Update(Action<bool, Exception> callback, ITSystem listToSave)
        {
            throw new NotImplementedException();
        }

        public void Search(Action<List<ITSystem>, Exception> callback, string SearchString)
        {
            throw new NotImplementedException();
        }

        public void Reload(Action<List<ITSystem>, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}