﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Emlak.Models;

public partial class Ilan
{
    public int Id { get; set; }

    public int? Fiyat { get; set; }

    public int? Durum { get; set; }

    public int? Tip { get; set; }

    public int? Alan { get; set; }

    public int? OdaSayisi { get; set; }

    public int? BanyoSayisi { get; set; }

    public int? Kat { get; set; }

    public string? Adres { get; set; }

    public int? Mahalle { get; set; }

    public int? Semt { get; set; }

    public int? Sehir { get; set; }

    public string? Telefon { get; set; }

    public DateTime? Tarih { get; set; }

    public string? Aciklama { get; set; }

    public virtual Durum? DurumNavigation { get; set; }

    public virtual Mahalle? MahalleNavigation { get; set; }

	[Display(Name = "Resim")]
	public virtual ICollection<Resim> Resims { get; set; } = new List<Resim>();

    public virtual Sehir? SehirNavigation { get; set; }

    public virtual Semt? SemtNavigation { get; set; }

    public virtual Tip? TipNavigation { get; set; }
}
