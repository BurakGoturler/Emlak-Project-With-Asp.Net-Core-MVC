using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Emlak.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Emlak.MetaData;

public class IlanMetaData
{
    [Key]
    public int Id { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Girilen fiyat pozitif bir sayı olmalıdır.")]
    public int? Fiyat { get; set; }

    public int? Durum { get; set; }
        
    public int? Tip { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Girilen alan pozitif bir sayı olmalıdır.")]
    public int? Alan { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Girilen oda sayısı pozitif bir sayı olmalıdır.")]
    public int? OdaSayisi { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Girilen banyo sayısı pozitif bir sayı olmalıdır.")]
    public int? BanyoSayisi { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Girilen kat sayısı pozitif bir sayı olmalıdır.")]
    public int? Kat { get; set; }

    public int? Sehir { get; set; }

    public int? Semt { get; set; }

    public int? Mahalle { get; set; }

    public string? Adres { get; set; }

    // [Range(0, int.MaxValue, ErrorMessage = "Girilen telefon sayısı pozitif bir sayı olmalıdır.")] // sayısal değerler için kontrolde çalışıyor sadece. int, decimal vs.
    [StringLength(11, MinimumLength = 11, ErrorMessage = "En az 11 karakter girmelisiniz.")] // string kontrol
    public string? Telefon { get; set; } // Eksi değer girilmesini engelleyemiyorum. Sorunu çözmek için Veri Tabanından string yerine int yapmalıyım. Çünkü Range attibute'ü sayısal veri tipleri için kullanılıyor.

    [DataType(DataType.Date)]
    public DateTime? Tarih { get; set; }

    [AllowHtml]
    public string? Aciklama { get; set; }

	[Display(Name = "Resim")]
	public int? Resim { get; set; }

    [Display(Name = "Durum")]
    public virtual Durum? DurumNavigation { get; set; }

    [Display(Name = "Mahalle")]
    public virtual Mahalle? MahalleNavigation { get; set; }

    [Display(Name = "Resim")]
    public virtual Resim? ResimNavigation { get; set; }

    [Display(Name = "Sehir")]
    public virtual Sehir? SehirNavigation { get; set; }

    [Display(Name = "Semt")]
    public virtual Semt? SemtNavigation { get; set; }

    [Display(Name = "Tip")]
    public virtual Tip? TipNavigation { get; set; }
}