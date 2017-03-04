using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ts3.pl.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj login")]
        [Display(Name = "Login")]
        public string DisplayName { get; set; }
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Nazwisko")]
        public string Vorname { get; set; }
        [Required(ErrorMessage = "Podaj adres e-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Podaj poprawny adres e-mail : xx@yy.com")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Podaj podaj 8 cyfrowe hasło!")]
        [MinLength(8)]
        public string Password { get; set; }
        public bool? IsSuperUser { get; set; }
        public DateTime? ModyficationDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Deleted { get; set; }
    }
}

