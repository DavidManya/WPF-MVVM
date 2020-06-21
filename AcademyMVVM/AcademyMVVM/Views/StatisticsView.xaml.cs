using System.Windows.Controls;
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

        private void SetStudentObj(Students selected)
        {
            txtDni.Text = selected.Dni;
            txtApellidos.Text = selected.LastName;
        }
        private void dgAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAlumnos.SelectedIndex != -1)
            {
                Students SelStudentsObj = this.dgAlumnos.SelectedItem as Students;
                SetStudentObj(SelStudentsObj);
            }
        }
    }
}
