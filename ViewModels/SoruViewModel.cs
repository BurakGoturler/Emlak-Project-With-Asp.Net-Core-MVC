using System.ComponentModel.DataAnnotations;

namespace Emlak.ViewModels
{
    public class SoruViewModel
    {
        [Required, Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required, Display(Name = "Tarih")]
        public string Tarih{ get; set; }

        [Required, Display(Name = "Soru")]
        public string Soru { get; set; }
    }
}
