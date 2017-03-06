namespace DatabaseTests
{
    using System.Collections.Generic;
    using System.Linq;

    using SystemAnsvarlig.Models;

    using Database;

    using MongoDB.Driver;

  

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseAPITests
    {

        public SystemApplication system = new SystemApplication(
                                              "Zenworks",
                                              "Appl_wiki",
                                              new List<string>() { "confluence", "Wikipedia" },
                                              new List<string>() { "Sondre Fingann", "Geir Ove" },
                                              "Supert system failer aldri",
                                              false,
                                              "60",
                                              "Egent");
        public List<SystemApplication> List = new List<SystemApplication>()
                                                  {
                                                      new SystemApplication(
                                                          "Wiki",
                                                          "Appl_wiki",
                                                          new List<string>() { "confluence", "Wikipedia" },
                                                          new List<string>() { "Sondre Fingann", "Geir Ove" },
                                                          "Supert system failer aldri",
                                                          false,
                                                          "60",
                                                          "Egent"),
                                                      new SystemApplication(
                                                          "Customer",
                                                          "Appl_Customer",
                                                          new List<string>() { "Classic", "Nasjonal" },
                                                          new List<string>() { "Helge Grimsty", "Unni" },
                                                          "Supert system failer aldri",
                                                          false,
                                                          "50",
                                                          "AD"),
                                                      new SystemApplication(
                                                          "Change",
                                                          "Appl_Change",
                                                          new List<string>() { "change ", "fk" },
                                                          new List<string>() { "Unni", "Mette" },
                                                          "Supert system failer aldri",
                                                          true,
                                                          "500",
                                                          "AD")
                                                  };

        

        [Test]
        public void RaspatoryInsert()
        {
         IRepository ss = new MongoRepository("TestDb", "SystemTest");

            ss.Add(this.system);
        }

        [Test]
        public void RaspatoryFind()
        {
            IRepository ss = new MongoRepository("TestDb", "SystemTest");
            ss.Add(this.system);
            var result = ss.Single(x => (x as SystemApplication).Name.Contains("works"));
        }
    

        //[Test]
        //public void RaspatoryDeleteList()
        //{


        //    ss.Delete(this.List[0]);
        //}
        //[Test]
        //public void RaspatoryDelete()
        //{
        //    IRepository<SystemApplication> ss = new MongoRepository<SystemApplication>("RepositoryTest");

        //    ss.Delete(this.system);
        //}




        ////[Test]
        ////public void Insert()
        ////{
        ////    var system = new SystemApplication(
        ////                     "Wiki",
        ////                     "Appl_wiki",
        ////                     new List<string>() { "confluence", "Wikipedia" },
        ////                     new List<string>() { "Sondre Fingann", "Geir Ove" },
        ////                     "Supert system failer aldri",
        ////                     false,
        ////                     "50",
        ////                     "AD");

        ////    DatabaseAPI ss = new DatabaseAPI();

        ////    ss.Insert(system);
        ////}
        ////[Test]
        ////public void get()
        ////{
        ////    DatabaseAPI ss = new DatabaseAPI();

        ////    var s = ss.Get();
        ////    Assert.Greater(s.Count, 0);

        ////}
        ////[Test]
        ////public void getWhere()
        ////{
        ////    DatabaseAPI ss = new DatabaseAPI();

        ////    var s = ss.GetWhere(x =>x.Lisens == false);
        ////    Assert.Greater(s.Count , 0);

        ////}

        ////[Test]
        ////public void Replace()
        ////{
        ////    DatabaseAPI ss = new DatabaseAPI();

        ////    var s = ss.GetWhere(x => x.Lisens == false);

        ////    s.First().Lisens = true;
        ////    ss.Replace(s.First());

        ////}
    }
}
