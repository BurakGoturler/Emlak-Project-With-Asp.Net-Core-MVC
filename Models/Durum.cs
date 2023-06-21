using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class Durum
{
    public int Id { get; set; }

    public string? Durum1 { get; set; }

    public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
}
