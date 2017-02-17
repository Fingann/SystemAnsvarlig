namespace ITSystemsTests
{
    using System;
    using System.Collections.Generic;

    using ITSystems;
    using ITSystems.Model;

    using NUnit.Framework;
    [TestFixture]
    public class ITSystemAPITests
    {
        [TestAttribute]
        public void Insert()
        {
            ITSystemAPI ss = new ITSystemAPI();
            ss.Insert(new ITSystem
            {
                Appl = "appl_ks",
                Alias = new List<string> { "Kundefront", "ks nasjonal" },
                SysAdministrator = new List<string> { "Unni", "Helge" },
                Name = "Kundefront",
                Description = "Lisensbelagt per organisasjon. Er gitt ut ifra hvordan hver otrganisasjon bestemmer og gi ut legitimasjon. Derfor har ikke vi noe med dette og gjøre",
                LastUpdated = DateTime.Now,
                Lisens = false,
                Price = string.Empty,
                Password = "AD"
            });
        }
    }
}