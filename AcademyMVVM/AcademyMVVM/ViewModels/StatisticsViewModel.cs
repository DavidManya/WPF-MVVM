using AcademyMVVM.Lib.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Lib.Core.Context.Interfaces;
using System.Windows.Input;
using System.Linq;
using AcademyMVVM.Lib.Models;
using System.Windows;

namespace AcademyMVVM.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        public StatisticsViewModel()
        {
            GetSubjectsCommand = new RouteCommand(GetSubjects);
            GetAvgbySubjectsCommand = new RouteCommand(GetAvgbySubjects);

            GetStudentsCommand = new RouteCommand(GetStudents);
            GetAvgbyStudentsCommand = new RouteCommand(GetAvgbyStudents);
        }

        public ICommand GetSubjectsCommand { get; set; }
        public ICommand GetAvgbySubjectsCommand { get; set; }

        public ICommand GetStudentsCommand { get; set; }
        public ICommand GetAvgbyStudentsCommand { get; set; }

        private string messageBoxText;
        private string caption = "Error de Proceso";
        private MessageBoxButton button = MessageBoxButton.OK;
        private MessageBoxImage icon = MessageBoxImage.Warning;
        
        private string _dniVM;
        public string DniVM
        {
            get { return _dniVM; }
            set
            {
                _dniVM = value;
                NotifyPropertyChanged();
            }
        }

        private string _lnameVM;
        public string LNameVM
        {
            get { return _lnameVM; }
            set
            {
                _lnameVM = value;
                NotifyPropertyChanged();
            }
        }

        private double _notamedVM;
        public double NotaMedVM
        {
            get { return _notamedVM; }
            set
            {
                _notamedVM = value;
                NotifyPropertyChanged();
            }
        }

        private double _notamaxVM;
        public double NotaMaxVM
        {
            get { return _notamaxVM; }
            set
            {
                _notamaxVM = value;
                NotifyPropertyChanged();
            }
        }

        private double _notaminVM;
        public double NotaMinVM
        {
            get { return _notaminVM; }
            set
            {
                _notaminVM = value;
                NotifyPropertyChanged();
            }
        }

        private Subjects _currentSubject = new Subjects();
        public Subjects CurrentSubject
        {
            get { return _currentSubject; }
            set
            {
                _currentSubject = value;
                NotifyPropertyChanged();
            }
        }


        private Students _currentStudent = new Students();
        public Students CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                NotifyPropertyChanged();
            }
        }

        private List<Subjects> _subjectsList = new List<Subjects>();
        public List<Subjects> SubjectsList
        {
            get { return _subjectsList; }
            set
            {
                _subjectsList = value;
                NotifyPropertyChanged();
            }

        }

        private List<string> _subjectsNameList = new List<string>();
        public List<string> SubjectsNameList
        {
            get { return _subjectsNameList; }
            set
            {
                _subjectsNameList = value;
                NotifyPropertyChanged();
            }

        }

        private List<Exams> _avgbysubjectList = new List<Exams>();
        public List<Exams> AvgbySubjectList
        {
            get
            {
                return _avgbysubjectList;
            }
            set
            {
                _avgbysubjectList = value;
                NotifyPropertyChanged();
            }
        }

        private List<Students> _studentsList = new List<Students>();
        public List<Students> StudentsList
        {
            get { return _studentsList; }
            set
            {
                _studentsList = value;
                NotifyPropertyChanged();
            }
        }

        private List<string> _studentsNameList = new List<string>();
        public List<string> StudentsNameList
        {
            get { return _studentsNameList; }
            set
            {
                _subjectsNameList = value;
                NotifyPropertyChanged();
            }
        }

        private List<Exams> _avgbystudentList = new List<Exams>();
        public List<Exams> AvgbyStudentList
        {
            get { return _avgbystudentList; }
            set
            {
                _avgbystudentList = value;
                NotifyPropertyChanged();
            }
        }

        public void GetListSubjects()
        {
            var repo = Subjects.DepCon.Resolve<IRepository<Subjects>>();
            SubjectsList = repo.QueryAll().ToList();
        }
        public List<string> GetSubjectsByName()
        {
            GetListSubjects();
            List<string> SubjectsNameListEV = new List<string>();
            foreach (Subjects subj in SubjectsList)
            {
                var name = subj.Name;
                SubjectsNameListEV.Add(name);
            }
            return SubjectsNameListEV;
        }
        public void GetSubjects()
        {
            GetListSubjects();
            SubjectsNameList = GetSubjectsByName();
        }

        public void GetAvgbySubjects()
        {
            var repo = Exams.DepCon.Resolve<IRepository<Exams>>();
            AvgbySubjectList = repo.QueryAll().ToList();
            AvgbySubjectList = AvgbySubjectList.FindAll(x => x.NameSubject == CurrentSubject.Name);

            MarksListVM();
            NotaMediaVM();
            NotaMaximaVM();
            NotaMinimaVM();
            AvgbySubjectList.Clear();
        }

        public void GetListStudents()
        {
            var repo = Students.DepCon.Resolve<IRepository<Students>>();
            StudentsList = repo.QueryAll().ToList();

            if (DniVM != null || LNameVM != null)
            {
                if (DniVM != null)
                {
                    StudentsList = StudentsList.FindAll(x => x.Dni == DniVM);
                }
                else
                {
                    StudentsList = StudentsList.FindAll(x => x.LastName.Contains(LNameVM));
                }

                if (StudentsList.Count == 1)
                {
                    CurrentStudent = StudentsList[0];
                    DniVM = "";
                    LNameVM = "";
                }
            }
        }
        public List<string> GetStudentsByName()
        {
            GetListStudents();
            List<string> StudentsNameListEV = new List<string>();
            foreach (Students stud in StudentsList)
            {
                string name = stud.LastName + ", " + stud.FirstName;
                StudentsNameListEV.Add(name);
            }
            return StudentsNameListEV;
        }
        public void GetStudents()
        {
            GetListStudents();
            StudentsNameList = GetStudentsByName();
        }

        public void GetAvgbyStudents()
        {
            var repo = Exams.DepCon.Resolve<IRepository<Exams>>();
            AvgbyStudentList = repo.QueryAll().ToList();
            AvgbyStudentList = AvgbyStudentList.FindAll(x => x.DniStudent == CurrentStudent.Dni);

            MarksListVM();
            NotaMediaVM();
            NotaMaximaVM();
            NotaMinimaVM();
            AvgbyStudentList.Clear();
        }

        public List<double> MarksListVM()
        {
            var marksList = new List<double>();

            if (CurrentSubject != null)
            {
                foreach (Exams subEx in AvgbySubjectList)
                {
                    marksList.Add(subEx.Mark);
                }
                CurrentStudent = null;
            }
            else if (CurrentStudent != null)
            {
                foreach (Exams stuEx in AvgbyStudentList)
                {
                    marksList.Add(stuEx.Mark);
                }
            }
            else
            {
                messageBoxText = "Debe seleccionar alguna fila";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            return marksList;
        }

        public void NotaMediaVM()
        {
            NotaMedVM = 0;
            var marksList = new List<double>();
            marksList = MarksListVM();

            if (marksList == null) { }

            else
            {
                NotaMedVM = marksList.Average();
            }
        }

        public void NotaMaximaVM()
        {
            NotaMaxVM = 0;

            var marksList = new List<double>();
            marksList = MarksListVM();

            if (marksList == null) { }

            else
            {
                NotaMaxVM = marksList.Max();
            }

        }

        public void NotaMinimaVM()
        {
            NotaMinVM = 0;

            var marksList = new List<double>();
            marksList = MarksListVM();

            if (marksList == null) { }

            else
            {
                NotaMinVM = marksList.Min();
            }
        }
    }
}
