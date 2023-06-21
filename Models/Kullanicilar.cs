using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class Kullanicilar
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? Sifre { get; set; }

    public int? RolId { get; set; }

    public virtual Rol? Rol { get; set; }
}
