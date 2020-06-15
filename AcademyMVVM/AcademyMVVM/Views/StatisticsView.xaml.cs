using System.Windows.Controls;
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
