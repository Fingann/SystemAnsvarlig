using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramNALImporter
{
    using System;
    using System.Collections.Generic;

    public interface ISystem
    {
        Guid Guid { get; }
        List<string> Alias { get; set; }

        string Appl { get; set; }

        string Description { get; set; }

        DateTime LastUpdated { get; set; }

        bool Lisens { get; set; }

        string Name { get; set; }

        string Password { get; set; }

        string Price { get; set; }

        List<string> SysAdministrator { get; set; }

        void Update(ISystem updatetdSystem);


    }
}