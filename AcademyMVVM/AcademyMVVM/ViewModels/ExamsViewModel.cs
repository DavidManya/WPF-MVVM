using AcademyMVVM.Lib.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Lib.Core.Context.Interfaces;
using System.Windows.Input;
using System.Linq;
using AcademyMVVM.Lib.Models;

namespace AcademyMVVM.ViewModels
{
    public class ExamsViewModel : ViewModelBase
    {
        public ExamsViewModel()
        {
            GetExamsCommand = new RouteCommand(GetExams);
            SaveExamsCommand = new RouteCommand(SaveExams);
            EditExamsCommand = new RouteCommand(EditExams);
            DelExamsCommand = new RouteCommand(DelExams);
            GetListSubjectsCommand = new RouteCommand(GetListSubjects);
            GetListStudentsCommand = new RouteCommand(GetListStudents);

            DateVM = DateTime.Now;
        }

        public ICommand GetExamsCommand { get; set; }
        public ICommand SaveExamsCommand { get; set; }
        public ICommand DelExamsCommand { get; set; }
        public ICommand EditExamsCommand { get; set; }
        public ICommand GetListSubjectsCommand { get; set; }
        public ICommand GetListStudentsCommand { get; set; }

        private string _currentSubjectNameVM;
        public string CurrentSubjectNameVM
        {
            get { return _currentSubjectNameVM; }
            set
            {
                _currentSubjectNameVM = value;
                NotifyPropertyChanged();
            }
        }

        private string _currentStudentNameVM;
        public string CurrentStudentNameVM
        {
            get { return _currentStudentNameVM; }
            set
            {
                _currentStudentNameVM = value;
                NotifyPropertyChanged();
            }
        }

        private Exams _currentExamEV;
        public Exams CurrentExamEV
        {
            get { return _currentExamEV; }
            set
            {
                _currentExamEV = value;
                NotifyPropertyChanged("CurrentExam");
                NotifyPropertyChanged("CanShowInfo");
            }
        }

        private DateTime _dateVM;
        public DateTime DateVM
        {
            get { return _dateVM; }
            set
            {
                _dateVM = value;
                NotifyPropertyChanged();
            }
        }

        private Double _notaVM;
        public Double NotaVM
        {
            get { return _notaVM; }
            set
            {
                _notaVM = value;
                NotifyPropertyChanged();
            }
        }

        List<Subjects> _subjectsListEV;
        public List<Subjects> SubjectsListEV
        {
            get { return _subjectsListEV; }
            set
            {
                _subjectsListEV = value;
                NotifyPropertyChanged();
            }

        }


        List<string> _subjectsNameListEV;
        public List<string> SubjectsNameListEV
        {
            get { return _subjectsNameListEV; }
            set
            {
                _subjectsNameListEV = value;
                NotifyPropertyChanged();
            }

        }

        public void GetExams()
        {

        }

        public void SaveExams()
        {

        }

        public void EditExams()
        {

        }

        public void DelExams()
        {

        }

        public void GetListSubjects()
        {

        }

        public void GetListStudents()
        {

        }
    }
}
