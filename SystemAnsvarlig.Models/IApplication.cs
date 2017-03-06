namespace SystemAnsvarlig.Models
{
    using System;
    using System.Collections.Generic;

    using Database;

    
    public interface IApplication : IMongoID
    {
   

    List<string> Alias { get; set; }

    string Appl { get; set; }

    string Description { get; set; }

    DateTime LastUpdated { get; set; }

    bool Lisens { get; set; }

    string Name { get; set; }

    string Password { get; set; }

    string Price { get; set; }

    List<string> SysAdministrator { get; set; }

    }
}
