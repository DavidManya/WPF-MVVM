using System;
using System.Collections.Generic;
using System.Text;
using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using System.Linq;

namespace AcademyMVVM.Lib.Models
{
    public class Subjects : Entity
    {
        public string Name { get; set; }
        public string Teacher { set; get; }

        public virtual List<Exams> Exams { get; set; }
        public virtual List<Courses> Courses { get; set; }

        public Subjects()
        {

        }

        public Subjects(string name, string teacher)
        {
            Name = name;
            Teacher = teacher;
        }

        public SaveResult<Subjects> Save()
        {
            return base.Save<Subjects>();
        }

        public SaveResult<Subjects> Delete()
        {
            var saveResult = base.Delete<Subjects>();

            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var validationResult = new ValidationResult
            {
                IsSuccess = true
            };

            ValidateName(validationResult);
            ValidateTeacher(validationResult);

            return validationResult;
        }

        public void ValidateName(ValidationResult validationResult)
        {
            var vr = ValidateName(this.Name);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateTeacher(ValidationResult validationResult)
        {
            var vr = ValidateTeacher(this.Teacher);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }

        }

        public static ValidationResult<string> ValidateName(string name, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("No ha introducido el nombre de la asignatura");
            }

            #region check duplication
            var repo = DepCon.Resolve<IRepository<Subjects>>();
            var entityWithName = repo.QueryAll().FirstOrDefault(s => s.Name == name);

            if (currentId == default && entityWithName != null)
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add($"Ya existe una asignatura con ese nombre {name}");
            }
            else if (currentId != default && entityWithName.Id != currentId && entityWithName != null)
            {
                // on update
                if(entityWithName.Name == name)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"Ya existe una asignatura con ese nombre {name}");
                }
            }
            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }

        public static ValidationResult<string> ValidateExistSub(string name, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("No ha introducido el nombre de la asignatura");
            }

            #region check duplication
            var repo = DepCon.Resolve<IRepository<Subjects>>();
            var entityWithName = repo.QueryAll().FirstOrDefault(s => s.Name == name);

            if (entityWithName.Name == null)
            {
                output.IsSuccess = false;
                output.Errors.Add($"No existe una asignatura con este nombre {name}");
            }
            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }
        public static ValidationResult<string> ValidateTeacher(string name)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(name))
            {
                output.IsSuccess = false;
                output.Errors.Add("No ha introducido el nombre del profesor");
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = name;
            }

            return output;
        }
    }
}
