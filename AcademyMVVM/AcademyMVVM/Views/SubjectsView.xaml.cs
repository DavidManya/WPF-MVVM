using System.Windows.Controls;
using AcademyMVVM.ViewModels;

namespace AcademyMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para SubjectsView.xaml
    /// </summary>
    public partial class SubjectsView : UserControl
    {    
        SubjectsViewModel ViewModel { get; set; }

        public SubjectsView()
        {
            InitializeComponent();

            ViewModel = new SubjectsViewModel();
            DataContext = ViewModel;
        }
    }
}
