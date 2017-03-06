﻿namespace SystemAnsvarlig.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Database;

  
    public class SystemApplication : IApplication
    {


        public SystemApplication()
        {

            Id = Guid.NewGuid().ToString();

        }

        public SystemApplication(
            string name,
            string appl,
            List<string> alias,
            List<string> sysAdmin,
            string description,
            bool lisens,
            string price,
            string pass)
            : this()
        {
            this.Name = name;
            this.Appl = appl;
            this.Alias = alias;
            this.SysAdministrator = sysAdmin;
            this.Description = description;
            this.Lisens = lisens;
            this.Password = pass;
            this.Price = price;
        }
     

        

        public List<string> Alias { get; set; } = new List<string>();

        public string Appl { get; set; } = "Appl_";

        public string Description { get; set; } = String.Empty;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public bool Lisens { get; set; } = false;

        public string Name { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Price { get; set; } = String.Empty;

        public List<string> SysAdministrator { get; set; } = new List<string>();

        public void Update(SystemApplication updatetdSystem)
        {
            Alias = updatetdSystem.Alias;

            Appl = updatetdSystem.Appl;

            Description = updatetdSystem.Description;

            LastUpdated = updatetdSystem.LastUpdated;

            Lisens = updatetdSystem.Lisens;

            Name = updatetdSystem.Name;

            Password = updatetdSystem.Password;

            Price = updatetdSystem.Price;

            SysAdministrator = SysAdministrator;
        }

        public string aliasString()
        {
            return this.Alias.Count > 0 ? this.Alias.Aggregate((a, b) => a + " " + b) : string.Empty;
        }
        public string SysAdminString()
        {
            return this.SysAdministrator.Count > 0 ? this.SysAdministrator.Aggregate((a, b) => a + " " + b) : string.Empty;
        }

        public override string ToString()
        {
            return this.Name + ", " + this.Appl;
        }

        //public override bool Equals(object obj)
        //{
        //    var item = obj as SystemApplication;

        //    return item?.ID == this.ID;
        //}

        public string Id { get; set; }
    }
}
