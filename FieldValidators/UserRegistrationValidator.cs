using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldValidatorAPI;

// https://www.youtube.com/watch?v=YT8s-90oDC0 Minute 1:13:00 

namespace ClubMembershipApplication.FieldValidators
{
    public class UserRegistrationValidator:IFieldValidator
    {
        const int FirstNameMinLength = 2;
        const int FirstNameMaxLength = 100;
        const int LastNameMinLength = 2;
        const int LastNameMaxLength = 100;

        delegate bool EmailExistsDel(string emailAddress);
        FieldValidatorDel _fieldValidatorDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        RequiredValidDel _requiredValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternMatchValidDel _patternMatchValidDel = null;
        CompareFieldsValidDel _compareFieldsValidDel = null;

        string[] fieldArray = null;
        public string[] FieldArray
        {
            get
            {
                if(fieldArray == null)
                {
                    fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                }
                return fieldArray;
            }

        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;
        public UserRegistrationValidator() { }

        public void InitializeValidatorDelegates()
        {
            _requiredValidDel = CommonFieldValidatorFunctions.RequiredFieldValidDel;
            _stringLengthValidDel = CommonFieldValidatorFunctions.StringLengthValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.DateValidDel;
            _patternMatchValidDel = CommonFieldValidatorFunctions.PatternMatchValidDel;
            _compareFieldsValidDel = CommonFieldValidatorFunctions.CompareFieldsValidDel;
        }
    }
}
