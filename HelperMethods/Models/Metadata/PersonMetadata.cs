using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelperMethods.Models
{
    [DisplayName("New Person")]
    public partial class PersonMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }

        [DisplayName("First")]
        public string FirstName { get; set; }

        [DisplayName("Last")]
        public string LastName { get; set; }

        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DisplayName("Approved")]
        public bool IsApproved { get; set; }

        [UIHint("Enum")]
        public Role Role { get; set; }
    }
}