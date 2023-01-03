using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class RegisterModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastName { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public int CustomerID { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{2}-[0-9]{6}$",
         ErrorMessage = "Reference number format is not valid.ex:AA-999999")]
        public string ReferenceNumber { get; set; }
        [DefaultValue("test@ani.co.uk")]
        [RegularExpression(@"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$",
         ErrorMessage = "Incorrect Email Format")]
        public string EmailId { get; set; }
        [DefaultValue("14/08/1990")]
        public string DOB { get; set; }
    }
}