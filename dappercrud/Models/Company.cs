using System.ComponentModel.DataAnnotations;

namespace dappercrud.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Display(Name="Company Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z\ ]{5,30}$", ErrorMessage = "incorrect name is inserted")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\ ]+$",ErrorMessage ="Incorrect city name")]
        public string City { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\ ]+$",ErrorMessage ="state name is incorrect")]
        public string State { get; set; }
        [Required]
        [RegularExpression(@"^\d{6}$",ErrorMessage ="incorrect pincode")]
        public string PostalCode { get; set; }
    }
}
