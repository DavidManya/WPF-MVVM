using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using AcademyMVVM.Lib.Models;
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

        private void SetStudentObj(Students selected)
        {
            txtDni.Text = selected.Dni;
            txtNombre.Text = selected.FirstName;
            txtApellidos.Text = selected.LastName;
            txtEmail.Text = selected.Email;
        }
        private void SetCourseObj(Courses selected)
        {
            cmbListCurAsi.SelectedItem = selected.NameSubject;
            dtpCurMat.DisplayDate = selected.DateEnrolment;
            txtNumSill.Text = Convert.ToString(selected.ChairNumber);
        }

        private void SetExamObj(Exams selected)
        {
            cboListAsiExa.SelectedItem = selected.NameSubject;
            dtpExamExa.DisplayDate = selected.DateExam;
            txtNotaExa.Text = Convert.ToString(selected.Mark);
        }

        private void dgAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgAlumnos.SelectedIndex != -1)
            {
                Students SelStudentsObj = this.dgAlumnos.SelectedItem as Students;
                SetStudentObj(SelStudentsObj);
            }
        }

        private void dgCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCursos.SelectedIndex != -1)
            {
                Courses SelCoursesObj = this.dgCursos.SelectedItem as Courses;
                SetCourseObj(SelCoursesObj);
            }
        }

        private void dgExamenes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgExamenes.SelectedIndex != -1)
            {
                Exams SelExamsObj = this.dgExamenes.SelectedItem as Exams;
                SetExamObj(SelExamsObj);
            }
        }
    }
}
