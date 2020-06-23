using System;
using Common.Lib.Core;
using Common.Lib.Infrastructure;

namespace AcademyMVVM.Lib.Models
{
    public class Exams : Entity
    {
        public string NameSubject { get; set; }
        public string DniStudent { get; set; }
        public DateTime DateExam { get; set; }
        public double Mark { get; set; }

        //public virtual Subjects Subjects { get; set; }
        //public virtual Students Students { get; set; }


        public Exams()
        {

        }

        public SaveResult<Exams> Save()
        {
            var saveResult = base.Save<Exams>();
            return saveResult;
        }

        public DeleteResult<Exams> Delete()
        {
            var deleteResult = base.Delete<Exams>();

            return deleteResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();
            ValidateDate(output);
            if (output.IsSuccess)
            {
                ValidateMark(output);
            }

            return output;
        }

        public void ValidateMark(ValidationResult validationResult)
        {
            var vr = ValidateMark(this.Mark.ToString());

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateDate(ValidationResult validationResult)
        {
            var vr = ValidateDate(this.DateExam.ToString());

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public static ValidationResult<double> ValidateMark(string markText)
        {
            var output = new ValidationResult<double>()
            {
                IsSuccess = true
            };

            var markNumber = 0.0;
            var isConversionOk = false;

            if (string.IsNullOrEmpty(markText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar una nota");
            }
            else
            {
                // check format conversion
                isConversionOk = Double.TryParse(markText, out markNumber);

                if (!isConversionOk)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"No se puede convertir {markNumber} en número");
                }
            }

            if (output.IsSuccess)
                output.ValidatedResult = markNumber;

            return output;
        }

        public static ValidationResult<DateTime> ValidateDate(string dateText)
        {
            var output = new ValidationResult<DateTime>()
            {
                IsSuccess = true
            };

            var datetime = new DateTime();
            var isConversionOk = false;

            if (string.IsNullOrEmpty(dateText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar una fecha");
            }
            else
            {
                // check format conversion
                isConversionOk = DateTime.TryParse(dateText, out datetime);

                if (!isConversionOk)
                {
                    output.IsSuccess = false;
                    output.Errors.Add($"No se puede convertir {datetime} en fecha");
                }
            }

            if (output.IsSuccess)
                output.ValidatedResult = datetime;

            return output;
        }
    }
}
