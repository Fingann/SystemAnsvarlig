namespace ITSystems
{
    using System.Collections.Generic;
    using System.Linq;

    using ITSystems.Model;

    using NinjaNye.SearchExtensions;

    public class ITSystemAPI
    {
        private readonly JsonHandler.JsonHandler Handler = new JsonHandler.JsonHandler();

        private List<ITSystem> LoadedList;

        public ITSystemAPI()
        {
            this.LoadedList = this.Handler.LoadJson();
        }

        public List<ITSystem> Reload()
        {
            this.LoadedList = this.Handler.LoadJson();

            return this.LoadedList;
        }

        public void Delete(ITSystem systemToDelete)
        {
            this.LoadedList.Remove(systemToDelete);
            this.SaveITSystemList();
        }

        public List<ITSystem> Get()
        {
            return this.LoadedList;
        }

        public void Insert(ITSystem systemToInsert)
        {
            this.LoadedList.Add(systemToInsert);
            this.SaveITSystemList();
        }

        public List<ITSystem> Search(string search)
        {
            var s2 =
                this.LoadedList.Search(
                        x => x.Name.ToLower(),
                        x => x.Appl.ToLower(),
                        x => x.Description.ToLower(),
                        x => x.aliasString().ToLower(),
                        x => x.SysAdminString().ToLower())
                    .Containing(search.ToLower().Split(' '))
                    .ToRanked().Reverse();

            var topResults = s2.Select(x => x.Item).ToList();
            return topResults;
        }

        public void Update(ITSystem systemToSave)
        {
            var index = this.LoadedList.FindIndex(x => x.Guid == systemToSave.Guid);
            this.LoadedList.RemoveAt(index);
            this.LoadedList.Insert(index, systemToSave);
            this.SaveITSystemList();
        }

        private void SaveITSystemList()
        {
            this.Handler.SaveJson(this.LoadedList);
        }
    }
}