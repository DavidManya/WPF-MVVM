using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common.Lib.Core.Context.Interfaces;
using AcademyMVVM.Lib.Models;
using AcademyMVVM.ViewModels;

namespace AcademyMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {        
        StatisticsViewModel ViewModel { get; set; }

        public StatisticsView()
        {
            InitializeComponent();

            ViewModel = new StatisticsViewModel();
            DataContext = ViewModel;
        }
    }
}
