using System;
using System.Collections.Generic;
using System.Text;
using Common.Lib.Core;
using Common.Lib.Core.Context.Interfaces;
using Common.Lib.Infrastructure;
using System.Linq;

namespace AcademyMVVM.Lib.Models
{
    public class Courses : Entity
    {
        public string NameSubject { get; set; }
        public string DniStudent { get; set; }
        public DateTime DateEnrolment { get; set; }
        public int ChairNumber { get; set; }

        public virtual Subjects Subjects { get; set; }
        public virtual Students Students { get; set; }

        public Courses()
        {

        }

        public Courses(string namesubject, string dnistudent, DateTime dateenrolment, int chairnumber)
        {
            NameSubject = namesubject;
            DniStudent = dnistudent;
            DateEnrolment = dateenrolment;
            ChairNumber = chairnumber;
        }

        public SaveResult<Courses> Save()
        {
            return base.Save<Courses>();
        }

        public SaveResult<Courses> Delete()
        {
            var saveResult = base.Delete<Courses>();

            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var validationResult = new ValidationResult
            {
                IsSuccess = true
            };

            ValidateChairNumber(validationResult);

            return validationResult;
        }

        public void ValidateChairNumber(ValidationResult validationResult)
        {
            var vr = ValidateChairNumber(this.ChairNumber.ToString(), this.NameSubject);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public static ValidationResult<int> ValidateChairNumber(string chairNumberText, string namesubject)
        {
            var output = new ValidationResult<int>()
            {
                IsSuccess = true
            };

            var chairNumber = 0;
            var isConversionOk = false;

            #region check null or empty
            if (string.IsNullOrEmpty(chairNumberText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar el número de silla");
            }
            #endregion

            #region check format conversion
            isConversionOk = int.TryParse(chairNumberText, out chairNumber);

            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add($"No se puede convertir {chairNumber} en número");
            }
            #endregion

            #region check if the char is already in use
            if (isConversionOk)
            {
                var repo = DepCon.Resolve<IRepository<Courses>>();
                var entityWithNumber = repo.QueryAll().FirstOrDefault(s => s.NameSubject == namesubject && s.ChairNumber == chairNumber);

                if (entityWithNumber != null)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"Ya existe un alumno en la silla {chairNumber}");
                }
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = chairNumber;

            return output;
        }
    }
}
