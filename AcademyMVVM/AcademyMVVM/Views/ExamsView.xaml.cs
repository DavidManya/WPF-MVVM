using System.Windows.Controls;
using AcademyMVVM.ViewModels;

namespace AcademyMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para ExamsView.xaml
    /// </summary>
    public partial class ExamsView : UserControl
    {       
        ExamsViewModel ViewModel { get; set; }

        public ExamsView()
        {
            InitializeComponent();

            ViewModel = new ExamsViewModel();
            DataContext = ViewModel;
        }
    }
}
