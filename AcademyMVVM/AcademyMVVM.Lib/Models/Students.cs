﻿using System;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.Infrastructure;
using Common.Lib.Infrastructure.Interfaces;
using System.Linq;

namespace AcademyMVVM.Lib.Models
{
    public class Students : Entity
    {
        public string Dni { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public virtual List<Exams> Exams { get; set; }
        //public virtual List<Courses> Courses { get; set; }

        public Students()
        {

        }

        public SaveResult<Students> Save()
        {
            return base.Save<Students>();
        }

        public DeleteResult<Students> Delete()
        {
            var deleteResult = base.Delete<Students>();

            return deleteResult;
        }

        public override ValidationResult Validate()
        {
            var output = base.Validate();

            ValidateDni(output);
            if (output.IsSuccess)
            {
                ValidateFName(output);
                if (output.IsSuccess)
                {
                    ValidateLName(output);
                    if (output.IsSuccess)
                    {
                        ValidateEmail(output);
                    }
                }
            }

            return output;
        }

        public Students Clone()
        {
            return Clone<Students>();
        }

        public override T Clone<T>()
        {
            var output = base.Clone<T>() as Students;

            output.Dni = this.Dni;
            output.FirstName = this.FirstName;
            output.LastName = this.LastName;
            output.Email = this.Email;

            return output as T;
        }

        #region Static Validations
        public static ValidationResult<string> ValidateDni(string dni, Guid currentId = default)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar DNI de alumn@");
            }
            else if (dni.Length < 9)
            {
                output.IsSuccess = false;
                output.Errors.Add("El DNI del alumno no tiene un formato correcto");
            }

            #region check duplication
            var repo = DepCon.Resolve<IRepository<Students>>();
            var entityWithDni = repo.QueryAll().FirstOrDefault(s => s.Dni == dni);

            if (currentId == default && entityWithDni != null)
            {
                // on create
                output.IsSuccess = false;
                output.Errors.Add("Ya existe alumn@ con este DNI");
            }
            else if (currentId != default && entityWithDni != null && entityWithDni.Id != currentId)
            {
                if (entityWithDni.Dni == dni)
                {
                    // on update
                    output.IsSuccess = false;
                    output.Errors.Add("Ya existe alumn@ con este DNI");
                }
            }
            #endregion

            if (output.IsSuccess)
                output.ValidatedResult = dni;

            return output;
        }

        public static ValidationResult<string> ValidateExist(string dni)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(dni))
            {
                output.IsSuccess = false;
                output.Errors.Add("El DNI no puede estar vacío");
            }
            else if (dni.Length < 9)
            {
                output.IsSuccess = false;
                output.Errors.Add("El DNI no tiene un formato correcto");
            }

            #region check existence
            var repo = DepCon.Resolve<IRepository<Students>>();
            var entityWithDni = repo.QueryAll().FirstOrDefault(s => s.Dni == dni);

            if (entityWithDni == null)
            {
                output.IsSuccess = false;
                output.Errors.Add($"No existe alumn@ con ese DNI {dni}");
            }
            #endregion

            if (output.IsSuccess)
            {
                output.ValidatedResult = dni;
            }

            return output;
        }

        public static ValidationResult<string> ValidateFName(string fname)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(fname))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar el nombre");
            }

            if (output.IsSuccess)
                output.ValidatedResult = fname;

            return output;
        }

        public static ValidationResult<string> ValidateLName(string lname)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(lname))
            {
                output.IsSuccess = false;
                output.Errors.Add("Debe informar los apellidos");
            }

            if (output.IsSuccess)
                output.ValidatedResult = lname;

            return output;
        }

        public static ValidationResult<string> ValidateEmail(string email)
        {
            var output = new ValidationResult<string>()
            {
                IsSuccess = true
            };

            if (string.IsNullOrEmpty(email))
            {
                output.IsSuccess = false;
                output.Errors.Add("No ha introducido el correo electrónico");
            }
            else
            { 
                string[] words = email.Split('@');
                if (words.Length == 1)
                {
                    output.IsSuccess = false;
                    output.Errors.Add("No ha introducido el correo correctamente");
                }

                if (!words[1].Contains('.') || !email.Contains('@'))
                {
                    output.IsSuccess = false;
                    output.Errors.Add("No ha introducido el correo correctamente");
                }
            }

            if (output.IsSuccess)
            {
                output.ValidatedResult = email;
            }
            return output;
        }
        #endregion

        #region Domain Validations
        public void ValidateDni(ValidationResult validationResult)
        {
            var vr = ValidateDni(this.Dni, this.Id);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateExist(ValidationResult validationResult)
        {
            var vr = ValidateExist(this.Dni);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }

        public void ValidateFName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateFName(this.FirstName);
            if (!validateNameResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateNameResult.Errors);
            }
        }

        public void ValidateLName(ValidationResult validationResult)
        {
            var validateNameResult = ValidateLName(this.LastName);
            if (!validateNameResult.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(validateNameResult.Errors);
            }
        }

        public void ValidateEmail(ValidationResult validationResult)
        {
            var vr = ValidateEmail(this.Email);

            if (!vr.IsSuccess)
            {
                validationResult.IsSuccess = false;
                validationResult.Errors.AddRange(vr.Errors);
            }
        }
        #endregion
    }
}
