﻿using System.Windows;
using SystemAnsvarlig.ViewModel;

namespace SystemAnsvarlig
{
    using MahApps.Metro.Controls;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            this.AllowsTransparency = true;
            //WindowStyle = WindowStyle.None;

        }
    }
}