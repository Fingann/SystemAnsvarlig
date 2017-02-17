namespace SystemAnsvarlig.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;

    using ITSystems.Model;

    using MaterialDesignThemes.Wpf;

    public class SystemManagerViewModel : ViewModelBase, IDataErrorInfo
    {

        public ITSystem Itsystem { get; set; }
        private bool IsNewSystemg = false;

        private ObservableCollection<string> sysAdmin = new ObservableCollection<string>() ;

        private ObservableCollection<string> alias = new ObservableCollection<string>();

        public SystemManagerViewModel(ITSystem system = null)
        {
            if (system == null)
            {
                this.Itsystem = new ITSystem();
                this.IsNewSystemg = true;
            }
            else
            {
                Itsystem = system;
               
            }

            Itsystem.SysAdministrator.ForEach(SysAdmin.Add);
            Itsystem.Alias.ForEach(Alias.Add);


            AddAliasCommand = new RelayCommand<string>(
   ExecuteAddAliasCommand);
            DeleteAliasCommand = new RelayCommand<string>(this.ExecuteDeleteAliasCommand);

            AddSysAdminCommand = new RelayCommand<string>(
   ExecuteAddSysAdminCommand);
            DeleteSysAdminCommand = new RelayCommand<string>(this.ExecuteDeleteSysAdminCommand);


            CloseCommand = new RelayCommand(() => MessengerInstance.Send<Tuple<ITSystem,bool>>(new Tuple<ITSystem, bool>(null, false)));
            
            ConfirmCommand= new RelayCommand(() => MessengerInstance.Send<Tuple<ITSystem, bool>>(new Tuple<ITSystem, bool>(Itsystem, this.IsNewSystemg)));

        }
        

        private void ExecuteDeleteSysAdminCommand(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                return;
            }
            this.sysAdmin.Remove(obj);
            Itsystem.SysAdministrator.Remove(obj);
            this.RaisePropertyChanged("SysAdmin");
        }

        private void ExecuteAddSysAdminCommand(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                return;
            }
            this.sysAdmin.Add(obj);
            Itsystem.SysAdministrator.Add(obj);
            this.RaisePropertyChanged("SysAdmin");
        }

        private void ExecuteDeleteAliasCommand(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                return;
            }
            this.Alias.Remove(obj);
            Itsystem.Alias.Remove(obj);
            this.RaisePropertyChanged("Alias");
        }

        private void ExecuteAddAliasCommand(string obj)
        {
            if (string.IsNullOrWhiteSpace(obj))
            {
                return;
            }
            this.Alias.Add(obj);
            Itsystem.Alias.Add(obj);
            this.RaisePropertyChanged("Alias");
        }


        public RelayCommand CloseCommand
        {
            get;
            private set;
        }

        public RelayCommand ConfirmCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> AddAliasCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> DeleteAliasCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> AddSysAdminCommand
        {
            get;
            private set;
        }

        public RelayCommand<string> DeleteSysAdminCommand
        {
            get;
            private set;
        }

        public ObservableCollection<string> SysAdmin
        {
            get
            {
                return this.sysAdmin;
            }
            set
            {
                this.sysAdmin = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> Alias
        {
            get
            {
                return this.alias;
            }
            set
            {
                this.alias = value;
                this.RaisePropertyChanged();
            }
        }

        //private List<string> alias;

        //private string appl;

        //private string description;

        //private DateTime lastUpdated;

        //private bool lisens;

        //private string name;

        //private string password;

        //private string price;

        //private List<string> sysAdministrator = new List<string>();

        //public List<string> Alias
        //{
        //    get
        //    {
        //        return this.alias;
        //    }

        //    set
        //    {
        //        this.alias = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public string Appl
        //{
        //    get
        //    {
        //        return this.appl;
        //    }

        //    set
        //    {
        //        this.appl = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public string Description
        //{
        //    get
        //    {
        //        return this.description;
        //    }

        //    set
        //    {
        //        this.description = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public DateTime LastUpdated
        //{
        //    get
        //    {
        //        return this.lastUpdated;
        //    }

        //    set
        //    {
        //        this.lastUpdated = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public bool Lisens
        //{
        //    get
        //    {
        //        return this.lisens;
        //    }

        //    set
        //    {
        //        this.lisens = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return this.name;
        //    }

        //    set
        //    {
        //        this.name = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public string Password
        //{
        //    get
        //    {
        //        return this.password;
        //    }

        //    set
        //    {
        //        this.password = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public string Price
        //{
        //    get
        //    {
        //        return this.price;
        //    }

        //    set
        //    {
        //        this.price = value;
        //        this.RaisePropertyChanged();
        //    }
        //}

        //public List<string> SysAdministrator
        //{
        //    get
        //    {
        //        return this.sysAdministrator;
        //    }

        //    set
        //    {
        //        this.sysAdministrator = value;
        //        this.RaisePropertyChanged();
        //    }
        //}
        public string this[string columnName]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Error { get; }
    }
}