using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Branch
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Provide name please.")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Provide email please.")]
        [StringLength(40, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Provide country please.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Provide city please.")]
        public int CityId { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
    }
}
