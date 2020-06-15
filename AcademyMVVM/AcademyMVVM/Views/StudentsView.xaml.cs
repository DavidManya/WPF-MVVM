using System.Windows.Controls;
using AcademyMVVM.ViewModels;

namespace AcademyMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para StudentsView.xaml
    /// </summary>
    public partial class StudentsView : UserControl
    {
        StudentsViewModel ViewModel { get; set; }

        public StudentsView()
        {
            InitializeComponent();

            ViewModel = new StudentsViewModel();
            DataContext = ViewModel;
        }
    }
}
