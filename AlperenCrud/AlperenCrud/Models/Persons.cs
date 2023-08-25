using System.ComponentModel.DataAnnotations;

namespace AlperenCrud.Models
{
    public class Persons
    {
        [Key]

        public int personId { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "İsim")]
        public string personName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Soyisim")]
        public string personSurname { get; set; }

        [Range(18, 65, ErrorMessage = "18 ile 65 yaş arasında bilgi giriniz")]
        [Display(Name = "Yaş")]
        public int personAge { get; set; }

        [Required(ErrorMessage = "Boş Geçmeyiniz")]
        [Display(Name = "Cinsiyet")]
        public string personGender { get; set; }

        [MaxLength(11, ErrorMessage = "Lutfen 11 Haneli TC Kimlik Numaranizi Giriniz")]
        [MinLength(11, ErrorMessage = "Lutfen 11 Haneli TC Kimlik Numaranizi Giriniz")]
        [Display(Name = "TC Kimlik No")]

        public string personIdentityId { get; set; }


    }
}
