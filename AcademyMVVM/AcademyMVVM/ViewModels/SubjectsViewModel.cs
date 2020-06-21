using AcademyMVVM.Lib.UI;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using AcademyMVVM.Lib.Models;
using System.Windows;
using Common.Lib.Core.Context;

namespace AcademyMVVM.ViewModels
{
    public class SubjectsViewModel : ViewModelBase
    {
        public SubjectsViewModel()
        {
            GetSubjectsCommand = new RouteCommand(GetSubjects);
            SaveSubjectsCommand = new RouteCommand(SaveSubjects);
            EditSubjectsCommand = new RouteCommand(EditSubjects);
            DelSubjectsCommand = new RouteCommand(DelSubjects);
        }

        public ICommand GetSubjectsCommand { get; set; }
        public ICommand SaveSubjectsCommand { get; set; }
        public ICommand DelSubjectsCommand { get; set; }
        public ICommand EditSubjectsCommand { get; set; }

        private string messageBoxText;
        private string caption = "Error de Proceso";
        private MessageBoxButton button = MessageBoxButton.OK;
        private MessageBoxImage icon = MessageBoxImage.Warning;

        private string _nameVM;
        public string NameVM
        {
            get { return _nameVM; }
            set
            {
                _nameVM = value;
                NotifyPropertyChanged();
            }
        }

        private string _teacherVM;
        public string TeacherVM
        {
            get { return _teacherVM; }
            set
            {
                _teacherVM = value;
                NotifyPropertyChanged();
            }
        }

        private Subjects _currentSubject;
        public Subjects CurrentSubject
        {
            get { return _currentSubject; }
            set
            {
                _currentSubject = value;
                NotifyPropertyChanged("CurrentSubject");
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

        public void GetSubjects()
        {
            var repo = Subjects.DepCon.Resolve<IRepository<Subjects>>();
            SubjectsList = repo.QueryAll().ToList();

            if (NameVM == "") { NameVM = null; }

            if (NameVM != null)
            {
                SubjectsList = SubjectsList.FindAll(x => x.Name == NameVM);
                if (SubjectsList.Count == 1)
                {
                    CurrentSubject = SubjectsList[0];
                    NameVM = CurrentSubject.Name;
                    TeacherVM = CurrentSubject.Teacher;
                }
            }

            if (SubjectsList.Count == 1)
            {
                CurrentSubject = SubjectsList[0];
                NameVM = CurrentSubject.Name;
                TeacherVM = CurrentSubject.Teacher;
            }
        }

        bool isEdit = false;
        public void SaveSubjects()
        {
            Subjects subject = new Subjects()
            {
                Name = NameVM,
                Teacher = TeacherVM,
            };

            if (isEdit == false)
                CurrentSubject = null;

            if (CurrentSubject != null)
                subject.Id = CurrentSubject.Id;

            subject.Save();

            if (subject.CurrentValidation.Errors.Count > 0)
            {
                messageBoxText = subject.CurrentValidation.Errors[0];
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            
            CurrentSubject = null;
            NameVM = null;
            TeacherVM = null;

            GetSubjects();

            isEdit = false;
        }

        public void EditSubjects()
        {
            isEdit = true;
            SaveSubjects();
        }

        public void DelSubjects()
        {
            if (CurrentSubject == null)
            {
                messageBoxText = "Debe seleccionar una asignatura";
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            else
            {
                Subjects subject = new Subjects();

                subject = CurrentSubject;

                subject.Delete();

                if (subject.CurrentValidation.Errors.Count > 0)
                {
                    messageBoxText = subject.CurrentValidation.Errors[0];
                    MessageBox.Show(messageBoxText, caption, button, icon);
                }

                CurrentSubject = null;
                NameVM = null;
                TeacherVM = null;

                GetSubjects();
            }
        }
    }
}
