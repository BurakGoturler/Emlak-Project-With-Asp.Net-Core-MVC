using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class Mahalle
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
}
