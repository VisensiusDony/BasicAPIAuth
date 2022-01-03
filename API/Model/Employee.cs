using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("tb_m_employee")]
    public class Employee
    {
        //NIK,firstName,lastName,phone,birthdate,salary,email,gender
        [Required(ErrorMessage = "{0} is a mandatory field")]
        [StringLength(maximumLength: 50, MinimumLength = 2,
        ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 50, MinimumLength = 2,
        ErrorMessage = "The property {0} should have {1} maximum characters and {2} minimum characters")]
        [Required(ErrorMessage = "{0} is a mandatory field")]
        public string LastName { get; set; }

        [Key]//penunjuk primary key
        public string NIK { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 15, MinimumLength = 2,ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        //[RegularExpression(@"^\\(?(\[0-9\]{3})\\)?\[-.●\]?(\[0-9\]{3})\[-.●\]?(\[0-9\]{4})$", ErrorMessage = "The PhoneNumber field is not a valid phone number")\]
        public string Phone { get; set; }

        //[CustomValidation(typeof(CustomerWeekendValidation), nameof(CustomerWeekendValidation.WeekendValidate))]
        [Required(ErrorMessage = "{0} is a mandatory field")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [Range(100000,100000000,ErrorMessage ="Your salary out of range")]
        [Required(ErrorMessage = "{0} is a mandatory field")]
        public int Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

        [Required(ErrorMessage = "{0} is a mandatory field")]
        [Range(0, 1, ErrorMessage = "Your Gender is Unavailable")]
        public Gender Gender { get; set; }
    }
    public enum Gender
    {
        Male = 0,
        Female = 1
    }
    public class CustomerWeekendValidation
    {
        public static ValidationResult WeekendValidate(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday
                ? new ValidationResult("The wekeend days aren't valid")
                : ValidationResult.Success;
        }
    }
}
