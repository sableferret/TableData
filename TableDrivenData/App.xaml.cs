using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using NickField.TableDrivenData.Presentation.ViewModels;
using NickField.TableDrivenData.Lib;

namespace TableDrivenData
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var columns = new List<IColumn>();
            var viewModel = new ViewModel(new DataProvider(), columns);
            var view = new MainWindow { DataContext = viewModel };
            view.Show();
        }
    }
}
