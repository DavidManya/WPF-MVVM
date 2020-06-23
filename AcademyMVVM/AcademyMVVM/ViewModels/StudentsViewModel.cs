using AcademyMVVM.Lib.UI;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using AcademyMVVM.Lib.Models;
using System.Windows;
using Common.Lib.Core.Context;
using System.Windows.Controls;

namespace AcademyMVVM.ViewModels
{
    public class StudentsViewModel :  ViewModelBase
    {
        public StudentsViewModel()
        {
            CleanCommand = new RouteCommand(Clean);
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

        public ICommand CleanCommand { get; set; }
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

        private string _markVM;
        public string MarkVM
        {
            get { return _markVM; }
            set
            {
                _markVM = value;
                NotifyPropertyChanged();
            }
        }

        private Students _currentStudent;
        public Students CurrentStudent
        {
            get { return _currentStudent; }
            set
            {
                _currentStudent = value;
                NotifyPropertyChanged();
            }
        }

        private string _currentSubjectC;
        public string CurrentSubjectC
        {
            get { return _currentSubjectC; }
            set
            {
                _currentSubjectC = value;
                NotifyPropertyChanged("CurrentSubjectC");
            }
        }

        private string _currentSubjectE;
        public string CurrentSubjectE
        {
            get { return _currentSubjectE; }
            set
            {
                _currentSubjectE = value;
                NotifyPropertyChanged("CurrentSubjectE");
            }
        }

        private Courses _currentCourse;
        public Courses CurrentCourse
        {
            get { return _currentCourse; }
            set
            {
                _currentCourse = value;
                NotifyPropertyChanged();
            }
        }

        private Exams _currentExam;
        public Exams CurrentExam
        {
            get { return _currentExam; }
            set
            {
                _currentExam = value;
                NotifyPropertyChanged();
            }
        }

        private List<Students> _studentsList;
        public List<Students> StudentsList
        {
            get { return _studentsList; }
            set
            {
                _studentsList = value;
                NotifyPropertyChanged();
            }

        }

        private List<Subjects> _subjectsList;
        public List<Subjects> SubjectsList
        {
            get { return _subjectsList; }
            set
            {
                _subjectsList = value;
                NotifyPropertyChanged();
            }

        }

        private List<Courses> _coursesList;
        public List<Courses> CoursesList
        {
            get { return _coursesList; }
            set
            {
                _coursesList = value;
                NotifyPropertyChanged();
            }

        }

        private List<string> _subjectsNameListC;
        public List<string> SubjectsNameListC
        {
            get { return _subjectsNameListC; }
            set
            {
                _subjectsNameListC = value;
                NotifyPropertyChanged();
            }

        }

        private List<string> _subjectsNameListE;
        public List<string> SubjectsNameListE
        {
            get { return _subjectsNameListE; }
            set
            {
                _subjectsNameListE = value;
                NotifyPropertyChanged();
            }

        }

        private List<Exams> _examsList;
        public List<Exams> ExamsList
        {
            get { return _examsList; }
            set
            {
                _examsList = value;
                NotifyPropertyChanged();
            }

        }

        public void Clean()
        {
            DniVM = null;
            FNameVM = null;
            LNameVM = null;
            EmailVM = null;
            StudentsList = null;
            ChairVM = 0;
            MarkVM = "0";
            CoursesList = null;
            SubjectsList = null;
            SubjectsNameListE = null;
            SubjectsNameListC = null;
            CurrentSubjectC = null;
            CurrentSubjectE = null;
            ExamsList = null;
            DateSVM = DateTime.Now;
            DateEVM = DateTime.Now;
        }
        public void GetStudents()
        {
            var repo = Students.DepCon.Resolve<IRepository<Students>>();
            StudentsList = repo.QueryAll().ToList();

            if (DniVM == "") { DniVM = null; }
            if (LNameVM == "") { LNameVM = null; }

            if ((DniVM != null || LNameVM != null) && isEdit == false)
            {
                if (DniVM != null)
                {
                    StudentsList = StudentsList.FindAll(x => x.Dni == DniVM);
                }
                else if (LNameVM != null)
                {
                    StudentsList = StudentsList.FindAll(x => x.LastName.Contains(LNameVM));
                }
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
            DniVM = null;
            FNameVM = null;
            LNameVM = null;
            EmailVM = null;

            GetStudents();

            isEdit = false;
        }

        public void EditStudents()
        {
            isEdit = true;
            SaveStudents();
        }

        public void DelStudents()
        {
            Students student = new Students();
            student = CurrentStudent;

            if (student != null)
            {
                student.Delete();

                if (student.CurrentValidation.Errors.Count > 0)
                {
                    messageBoxText = student.CurrentValidation.Errors[0];
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }

                DniVM = null;
                FNameVM = null;
                LNameVM = null;
                EmailVM = null;
            }
            else
            {
                messageBoxText = "Debe seleccionar alumn@";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }

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
            
            if (CurrentSubjectC == "")
            {
                GetListSubjectsC();
            }

            var repo = Courses.DepCon.Resolve<IRepository<Courses>>();
            CoursesList = repo.QueryAll().ToList();

            if (DniVM != null)
            {
                if (CurrentSubjectC == null) { CurrentSubjectC = ""; }
                if (CurrentSubjectC != "")
                {
                    CoursesList = CoursesList.FindAll(x => x.DniStudent == DniVM && x.NameSubject == CurrentSubjectC);
                }
                else
                {
                    CoursesList = CoursesList.FindAll(x => x.DniStudent == DniVM);
                }

                if (CoursesList.Count == 1)
                {
                    CurrentCourse = CoursesList[0];
                    CurrentSubjectC = CurrentCourse.NameSubject;
                    DateSVM = CurrentCourse.DateEnrolment;
                    ChairVM = CurrentCourse.ChairNumber;
                }
                else if (CoursesList.Count == 0)
                {
                    messageBoxText = "No hay datos para est@ alumn@";
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            else
            {
                CoursesList = null;
                messageBoxText = "Debe informar DNI de alumn@";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        public void SaveCourses()
        {
            Courses course = new Courses()
            {
                DniStudent = DniVM,
                NameSubject = CurrentSubjectC,
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
            CurrentSubjectC = "";
            DateSVM = DateTime.Now;
            ChairVM = 0;
            isEdit = false;
        }

        public void EditCourses()
        {
            isEdit = true;
            SaveCourses();
        }

        public void DelCourses()
        {
            Courses course = new Courses();
            course = CurrentCourse;

            if (course != null)
            {
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
            else
            {
                messageBoxText = "Debe seleccionar alumn@/curso";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        public void GetExams()
        {
            if (CurrentSubjectE == "")
            {
                GetListSubjectsE();
            }

            var repo = Exams.DepCon.Resolve<IRepository<Exams>>();
            ExamsList = repo.QueryAll().ToList();

            if (DniVM != null)
            {
                if (CurrentSubjectE == null) { CurrentSubjectE = ""; }
                if (CurrentSubjectE != "")
                {
                    ExamsList = ExamsList.FindAll(x => x.DniStudent == DniVM && x.NameSubject == CurrentSubjectE);
                }
                else
                {
                    ExamsList = ExamsList.FindAll(x => x.DniStudent == DniVM);
                }

                if (ExamsList.Count == 1)
                {
                    CurrentExam = ExamsList[0];
                    CurrentSubjectE = CurrentExam.NameSubject;
                    DateEVM = CurrentExam.DateExam;
                    MarkVM = Convert.ToString(CurrentExam.Mark).Replace(",", "."); //Passar a text canviant punt per coma
                }
                else if (ExamsList.Count == 0)
                {
                    messageBoxText = "No hay datos para est@ alumn@";
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }
            }
            else
            {
                ExamsList = null;
                messageBoxText = "Debe informar DNI de alumn@";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        public void SaveExams()
        {
            Exams exam = new Exams()
            {
                DniStudent = DniVM,
                NameSubject = CurrentSubjectE,
                DateExam = DateEVM,
                Mark = Convert.ToDouble(MarkVM.Replace(".", ",")),  //Passar a Double canviant coma per punt 
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
            CurrentSubjectE = "";
            DateEVM = DateTime.Now;
            MarkVM = "0";
            isEdit = false;

            GetExams();
        }

        public void EditExams()
        {
            isEdit = true;
            SaveExams();
        }

        public void DelExams()
        {
            Exams exam = new Exams();
            exam = CurrentExam;

            if (exam != null)
            {
                exam.Delete();

                if (exam.CurrentValidation.Errors.Count > 0)
                {
                    messageBoxText = exam.CurrentValidation.Errors[0];
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }

                DateEVM = DateTime.Now;
                MarkVM = "0";

                GetExams();
            }
            else
            {
                messageBoxText = "Debe seleccionar alumn@/exámen";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }
    }
}
