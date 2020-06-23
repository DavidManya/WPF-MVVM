using System;
using Common.Lib.Core;
using Common.Lib.Core.Context;
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

        //public virtual Subjects Subjects { get; set; }
        //public virtual Students Students { get; set; }

        public Courses()
        {

        }

        public SaveResult<Courses> Save()
        {
            return base.Save<Courses>();
        }

        public DeleteResult<Courses> Delete()
        {
            var deleteResult = base.Delete<Courses>();

            return deleteResult;
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
            var vr = ValidateChairNumber(this.ChairNumber.ToString(), this.NameSubject, this.DniStudent);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public static ValidationResult<int> ValidateChairNumber(string chairNumberText, string namesubject, string dniStudent)
        {
            var output = new ValidationResult<int>()
            {
                IsSuccess = true
            };

            var chairNumber = 0;
            var isConversionOk = false;

            if (string.IsNullOrEmpty(chairNumberText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar el número de silla");
            }
            else
            {
                // check format conversion
                isConversionOk = int.TryParse(chairNumberText, out chairNumber);

                if (!isConversionOk)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"No se puede convertir {chairNumber} en número");
                }
                else
                {
                    // check if the char is already in use
                    var repo = DepCon.Resolve<IRepository<Courses>>();
                    var entityWithNumber = repo.QueryAll().FirstOrDefault(s => s.NameSubject == namesubject && s.ChairNumber == chairNumber);

                    if (entityWithNumber != null && entityWithNumber.DniStudent != dniStudent)
                    {
                        output.IsSuccess = false;
                        output.Errors.Add($"Ya existe un alumno en la silla {chairNumber}");
                    }
                }
            }

            if (output.IsSuccess)
                output.ValidatedResult = chairNumber;

            return output;
        }
    }
}
