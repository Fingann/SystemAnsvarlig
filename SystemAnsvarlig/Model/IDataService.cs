using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemAnsvarlig.Model
{
    using ITSystems.Model;

    public interface IDataService
    {
        

        void Get(Action<List<ITSystem>, Exception> callback);
        void Delete(Action<bool, Exception> callback, ITSystem listToSave);
        void Insert(Action<bool, Exception> callback, ITSystem listToSave);
        void Update(Action<bool, Exception> callback, ITSystem listToSave);
        void Search(Action<List<ITSystem>, Exception> callback, string SearchString);
        void Reload(Action<List<ITSystem>, Exception> callback);


    }
}
