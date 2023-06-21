using System.ComponentModel.DataAnnotations;

namespace Emlak.ViewModels
{
	public class LoginViewModel
	{
		[Required, Display(Name = "Kullanıcı Adı")]
		public string KullaniciAdi { get; set; }

		[Required, Display(Name = "Şifre")]
		public string Sifre { get; set; }
	}
}