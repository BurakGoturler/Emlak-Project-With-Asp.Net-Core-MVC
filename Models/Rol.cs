using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public virtual ICollection<Kullanicilar> Kullanicilars { get; set; } = new List<Kullanicilar>();
}
