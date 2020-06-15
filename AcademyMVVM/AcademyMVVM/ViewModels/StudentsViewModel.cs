using AcademyMVVM.Lib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using AcademyMVVM.Lib.Models;
using System.Windows;
using Common.Lib.Core.Context;

namespace AcademyMVVM.ViewModels
{
    public class StudentsViewModel :  ViewModelBase
    {
        public StudentsViewModel()
        {
            GetStudentsCommand = new RouteCommand(GetStudents);
            SaveStudentsCommand = new RouteCommand(SaveStudents);
            EditStudentsCommand = new RouteCommand(EditStudents);
            DelStudentsCommand = new RouteCommand(DelStudents);

            GetCoursesCommand = new RouteCommand(GetCourses);
            SaveCoursesCommand = new RouteCommand(SaveCourses);
            EditCoursesCommand = new RouteCommand(EditCourses);
            DelCoursesCommand = new RouteCommand(DelCourses);

            GetListSubjectsCCommand = new RouteCommand(GetListSubjectsC);
            GetListSubjectsECommand = new RouteCommand(GetListSubjectsE);

            GetExamsCommand = new RouteCommand(GetExams);
            SaveExamsCommand = new RouteCommand(SaveExams);
            EditExamsCommand = new RouteCommand(EditExams);
            DelExamsCommand = new RouteCommand(DelExams);

            DateSVM = DateTime.Now;
            DateEVM = DateTime.Now;
        }

        public ICommand GetStudentsCommand { get; set; }
        public ICommand SaveStudentsCommand { get; set; }
        public ICommand DelStudentsCommand { get; set; }
        public ICommand EditStudentsCommand { get; set; }

        public ICommand GetCoursesCommand { get; set; }
        public ICommand SaveCoursesCommand { get; set; }
        public ICommand DelCoursesCommand { get; set; }
        public ICommand EditCoursesCommand { get; set; }

        public ICommand GetListSubjectsCCommand { get; set; }
        public ICommand GetListSubjectsECommand { get; set; }

        public ICommand GetExamsCommand { get; set; }
        public ICommand SaveExamsCommand { get; set; }
        public ICommand DelExamsCommand { get; set; }
        public ICommand EditExamsCommand { get; set; }

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

        private string _fnameVM;
        public string FNameVM
        {
            get { return _fnameVM; }
            set
            {
                _fnameVM = value;
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

        private string _emailVM;
        public string EmailVM
        {
            get { return _emailVM; }
            set
            {
                _emailVM = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _dateSVM;
        public DateTime DateSVM
        {
            get { return _dateSVM; }
            set
            {
                _dateSVM = value;
                NotifyPropertyChanged();
            }
        }

        private int _chairVM;
        public int ChairVM
        {
            get { return _chairVM; }
            set
            {
                _chairVM = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _dateEVM;
        public DateTime DateEVM
        {
            get { return _dateEVM; }
            set
            {
                _dateEVM = value;
                NotifyPropertyChanged();
            }
        }

        private Double _markVM;
        public Double MarkVM
        {
            get { return _markVM; }
            set
            {
                _markVM = value;
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
                NotifyPropertyChanged("CurrentStudent");
            }
        }

        private Subjects _currentSubjectC = new Subjects();
        public Subjects CurrentSubjectC
        {
            get { return _currentSubjectC; }
            set
            {
                _currentSubjectC = value;
                NotifyPropertyChanged("CurrentSubject");
            }
        }

        private Subjects _currentSubjectE = new Subjects();
        public Subjects CurrentSubjectE
        {
            get { return _currentSubjectE; }
            set
            {
                _currentSubjectE = value;
                NotifyPropertyChanged("CurrentSubject");
            }
        }

        private Courses _currentCourse = new Courses();
        public Courses CurrentCourse
        {
            get { return _currentCourse; }
            set
            {
                _currentCourse = value;
                NotifyPropertyChanged("CurrentCourse");
            }
        }

        private Exams _currentExam = new Exams();
        public Exams CurrentExam
        {
            get { return _currentExam; }
            set
            {
                _currentExam = value;
                NotifyPropertyChanged("CurrentExam");
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

        private List<Courses> _coursesList = new List<Courses>();
        public List<Courses> CoursesList
        {
            get { return _coursesList; }
            set
            {
                _coursesList = value;
                NotifyPropertyChanged();
            }

        }

        private List<string> _subjectsNameListC = new List<string>();
        public List<string> SubjectsNameListC
        {
            get { return _subjectsNameListC; }
            set
            {
                _subjectsNameListC = value;
                NotifyPropertyChanged();
            }

        }

        private List<string> _subjectsNameListE = new List<string>();
        public List<string> SubjectsNameListE
        {
            get { return _subjectsNameListE; }
            set
            {
                _subjectsNameListE = value;
                NotifyPropertyChanged();
            }

        }

        private List<Exams> _examsList = new List<Exams>();
        public List<Exams> ExamsList
        {
            get { return _examsList; }
            set
            {
                _examsList = value;
                NotifyPropertyChanged();
            }

        }

        public void GetStudents()
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
                    DniVM = CurrentStudent.Dni;
                    FNameVM = CurrentStudent.FirstName;
                    LNameVM = CurrentStudent.LastName;
                    EmailVM = CurrentStudent.Email;
                }
            }
        }

        bool isEdit = false;
        public void SaveStudents()
        {
            Students student = new Students()
            {
                Dni = DniVM,
                FirstName = FNameVM,
                LastName = LNameVM,
                Email = EmailVM,
            };

            if (isEdit == false)
                CurrentStudent = null;

            if (CurrentStudent != null)
                student.Id = CurrentStudent.Id;

            student.Save();

            if (student.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = student.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            CurrentStudent = null;
            DniVM = "";
            FNameVM = "";
            LNameVM = "";
            EmailVM = "";
            isEdit = false;

            GetStudents();
        }

        public void EditStudents()
        {
            var student = new Students();
            student = CurrentStudent;

            DniVM = CurrentStudent.Dni;
            FNameVM = CurrentStudent.FirstName;
            LNameVM = CurrentStudent.LastName;
            EmailVM = CurrentStudent.Email;

            isEdit = true;
        }

        public void DelStudents()
        {
            Students student = new Students();
            student = CurrentStudent;
            student.Delete();

            if (student.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = student.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            DniVM = "";
            FNameVM = "";
            LNameVM = "";
            EmailVM = "";

            GetStudents();
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

        public void GetListSubjectsC()
        {
            GetListSubjects();
            SubjectsNameListC = GetSubjectsByName();
        }
        public void GetListSubjectsE()
        {
            GetListSubjects();
            SubjectsNameListE = GetSubjectsByName();
        }
        
        public void GetCourses()
        {
            var repo = Courses.DepCon.Resolve<IRepository<Courses>>();
            CoursesList = repo.QueryAll().ToList();

            if (DniVM != null)
            {
                CoursesList = CoursesList.FindAll(x => x.DniStudent == DniVM);
                if (CoursesList.Count == 1)
                {
                    CurrentCourse = CoursesList[0];
                    CurrentSubjectC.Name = CurrentCourse.NameSubject; //no sé si funcionarà
                    DateSVM = CurrentCourse.DateEnrolment;
                    ChairVM = CurrentCourse.ChairNumber;
                }
            }
            else
            {
                messageBoxText = "Debe informar DNI del alumno";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        public void SaveCourses()
        {
            Courses course = new Courses()
            {
                DniStudent = DniVM,
                NameSubject= CurrentSubjectC.Name,
                DateEnrolment =DateSVM,
                ChairNumber = ChairVM,
            };

            if (isEdit == false)
                CurrentCourse = null;

            if (CurrentCourse != null)
                course.Id = CurrentCourse.Id;

            course.Save();

            if (course.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = course.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            GetCourses();

            CurrentCourse = null;
            CurrentSubjectC = null;
            DateSVM = DateTime.Now;
            ChairVM = 0;
            isEdit = false;
        }

        public void EditCourses()
        {
            var course = new Courses();
            course = CurrentCourse;

            CurrentSubjectC.Name = CurrentCourse.NameSubject;
            DateSVM = CurrentCourse.DateEnrolment;
            ChairVM = CurrentCourse.ChairNumber;

            isEdit = true;
        }

        public void DelCourses()
        {
            Courses course = new Courses();
            course = CurrentCourse;
            course.Delete();

            if (course.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = course.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            DateSVM = DateTime.Now;
            ChairVM = 0;

            GetCourses();
        }

        public void GetExams()
        {
            var repo = Exams.DepCon.Resolve<IRepository<Exams>>();
            ExamsList = repo.QueryAll().ToList();

            if (DniVM != null)
            {
                ExamsList = ExamsList.FindAll(x => x.DniStudent == DniVM);
                if (ExamsList.Count == 1)
                {
                    CurrentExam = ExamsList[0];
                    CurrentSubjectE.Name = CurrentExam.NameSubject; //no sé si funcionarà
                    DateEVM = CurrentExam.DateExam;
                    MarkVM = CurrentExam.Mark;
                }
            }
            else
            {
                messageBoxText = "Debe informar DNI del alumno";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        public void SaveExams()
        {
            Exams exam = new Exams()
            {
                DniStudent = DniVM,
                NameSubject = CurrentSubjectE.Name,
                DateExam = DateEVM,
                Mark = MarkVM,
            };

            if (isEdit == false)
                CurrentExam = null;

            if (CurrentExam != null)
                exam.Id = CurrentExam.Id;

            exam.Save();

            if (exam.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = exam.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            CurrentExam = null;
            CurrentSubjectE = null;
            DateEVM = DateTime.Now;
            MarkVM = 0;
            isEdit = false;

            GetExams();
        }

        public void EditExams()
        {
            var exam = new Exams();
            exam = CurrentExam;

            CurrentSubjectE.Name = CurrentExam.NameSubject;
            DateEVM = CurrentExam.DateExam;
            MarkVM = CurrentExam.Mark;
            isEdit = true;
        }

        public void DelExams()
        {
            Exams exam = new Exams();
            exam = CurrentExam;
            exam.Delete();

            if (exam.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = exam.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

            DateEVM = DateTime.Now;
            MarkVM = 0;

            GetCourses();
        }
    }
}
