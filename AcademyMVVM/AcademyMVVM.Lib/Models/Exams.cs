using System;
using System.Collections.Generic;
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

        public virtual Subjects Subjects { get; set; }
        public virtual Students Students { get; set; }


        public Exams()
        {

        }

        public Exams(string namesubject, string dnistudent, DateTime dateexam, Double mark)
        {
            NameSubject = namesubject;
            DniStudent = dnistudent;
            DateExam = dateexam;
            Mark = mark;
        }

        public SaveResult<Exams> Save()
        {
            var saveResult = base.Save<Exams>();
            return saveResult;
        }

        public SaveResult<Exams> Delete()
        {
            var saveResult = base.Delete<Exams>();

            return saveResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();
            ValidateDate(output);
            ValidateMark(output);

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

            #region check null or empty
            if (string.IsNullOrEmpty(markText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar una nota");
            }
            #endregion

            #region check format conversion

            isConversionOk = Double.TryParse(markText, out markNumber);

            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add($"No se puede convertir {markNumber} en número");
            }

            #endregion

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

            #region check null or empty
            if (string.IsNullOrEmpty(dateText))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar una fecha");
            }
            #endregion

            #region check format conversion
            isConversionOk = DateTime.TryParse(dateText, out datetime);

            if (!isConversionOk)
            {
                output.IsSuccess = false;
                output.Errors.Add($"No se puede convertir {datetime} en fecha");
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = datetime;

            return output;
        }
    }
}
