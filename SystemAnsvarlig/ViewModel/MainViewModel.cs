namespace SystemAnsvarlig.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using SystemAnsvarlig.Model;
    using SystemAnsvarlig.Views;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;

    using ITSystems.Model;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private ITSystem currentDisplayedSystem;

        private bool flyoutIsOpen;

        // new List<ITSystem>();
        private ObservableCollection<ITSystem> listOfSystems = new ObservableCollection<ITSystem>();

        private string searchText;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            this.CreateCommand = new RelayCommand(this.ExecuteCreateCommand);
            this.EditCommand = new RelayCommand<ITSystem>(this.ExecuteEditCommand);
            this.DeleteCommand = new RelayCommand<ITSystem>(DeleteSystem);

            this._dataService = dataService;
            this._dataService.Get(
                (item, error) =>
                    {
                        if (error != null) return;

                        item.ForEach(ListOfSystems.Add);
                         //ListOfSystems = item;
                    });

            this.MessengerInstance.Register<Tuple<ITSystem, bool>>(this, this.HandleDialogResult);
        }

        private void DeleteSystem(ITSystem obj)
        {
            this._dataService.Delete(((b, exception) => Console.WriteLine(b)),obj);
            ListOfSystems.Remove(obj);
        }

        public RelayCommand<ITSystem> DeleteCommand { get; private set; }

        public RelayCommand CreateCommand { get; private set; }

        public ITSystem CurrentDisplayedSystem
        {
            get
            {
                return this.currentDisplayedSystem;
            }

            set
            {
                this.currentDisplayedSystem = value;
                this.RaisePropertyChanged();
            }
        }

      

        public RelayCommand DialogClosedCommand { get; private set; }

        public RelayCommand<ITSystem> EditCommand { get; private set; }

        public bool FlyoutIsOpen
        {
            get
            {
                return this.flyoutIsOpen;
            }

            set
            {
                this.flyoutIsOpen = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<ITSystem> ListOfSystems
        {
            get
            {
                return this.listOfSystems;
            }

            set
            {
                this.listOfSystems = value;
                this.RaisePropertyChanged();
            }
        }

        public string SearchText
        {
            get
            {
                return this.searchText;
            }

            set
            {
                this._dataService.Search(
                    (item, error) =>
                        {
                            if (error != null) return;
                            ListOfSystems.Clear();
                            item.ForEach(ListOfSystems.Add);
                        },
                    value);
                this.searchText = value;
            }
        }

        private void ExecuteCreateCommand()
        {
            DialogHost.Show(
                new SystemManagerView { DataContext = new SystemManagerViewModel() },
                null,
                (sender, args) => { Console.WriteLine((sender as SystemManagerViewModel).Itsystem); });
        }

        private void ExecuteEditCommand(ITSystem system)
        {
            DialogHost.Show(
                new SystemManagerView { DataContext = new SystemManagerViewModel(system) },
                (sender, args) =>
                    {
                        Console.WriteLine(
                            ((args.Content as SystemManagerView).DataContext as SystemManagerViewModel).Itsystem);
                    });
        }

       

        private void HandleDialogResult(Tuple<ITSystem, bool> obj)
        {
            this.FlyoutIsOpen = false;
            var system = obj.Item1;
            var isNewSystem = obj.Item2;
            if (system == null) return;
            if (isNewSystem)
            {
                this._dataService.Insert((b, exception) => Console.WriteLine(b), system);
                ListOfSystems.Add(system);
                return;
            }

            this._dataService.Update((b, exception) => Console.WriteLine(b), system);
            var found = ListOfSystems.FirstOrDefault(x => x.Guid == system.Guid);
            ListOfSystems.Remove(found);
            ListOfSystems.Add(system);
         

        }

        ////}

        ////    base.Cleanup();
        ////    // Clean up if needed
        ////{

        ////public override void Cleanup()
    }
}