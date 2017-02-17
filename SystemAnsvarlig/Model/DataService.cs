using System;

namespace SystemAnsvarlig.Model
{
    using System.Collections.Generic;

    using ITSystems;
    using ITSystems.JsonHandler;
    using ITSystems.Model;

    public class DataService : IDataService
    {
      private ITSystemAPI systemApi = new ITSystemAPI();

     
        public void Get(Action<List<ITSystem>, Exception> callback)
        {
            callback(systemApi.Get(), null);

        }

        public void Delete(Action<bool, Exception> callback, ITSystem systemToDelete)
        {
            try
            {
                systemApi.Delete(systemToDelete);
            }
            catch (Exception ex)
            {
                callback(false, ex);
            }
            callback(true, null);
        }

        public void Insert(Action<bool, Exception> callback, ITSystem SystemToSave)
        {
            try
            {
                this.systemApi.Insert(SystemToSave);
            }
            catch (Exception ex)
            {
                callback(false, ex);
            }
            callback(true, null);
            
            
        }

        public void Update(Action<bool, Exception> callback, ITSystem systemToUpdate)
        {
            try
            {
                this.systemApi.Update(systemToUpdate);
            }
            catch (Exception ex)
            {
                callback(false, ex);
            }
            callback(true, null);
        }


        public void Search(Action<List<ITSystem>, Exception> callback, string searchString)
        {
            List<ITSystem> systems = null;
            if (string.IsNullOrEmpty(searchString))
            {
                callback(this.systemApi.Get(), null);
                return;
            }

            try
            {
               systems = this.systemApi.Search(searchString);
            }
            catch (Exception ex)
            {
                callback(systems, ex);
            }

            callback(systems, null);
        }

        public void Reload(Action<List<ITSystem>, Exception> callback)
        {

            callback(systemApi.Reload(), null);
        }
    }
}