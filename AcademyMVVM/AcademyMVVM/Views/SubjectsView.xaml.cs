using System.Windows.Controls;
using AcademyMVVM.Lib.Models;
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

        private void SetSubjectObj(Subjects selected)
        {
            txtAsignatura.Text = selected.Name;
            txtNomProf.Text = selected.Teacher;
        }

        private void dgAsignaturas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAsignaturas.SelectedIndex != -1)
            {
                Subjects SelSubjectsObj = this.dgAsignaturas.SelectedItem as Subjects;
                SetSubjectObj(SelSubjectsObj);
            }
        }
    }
}
