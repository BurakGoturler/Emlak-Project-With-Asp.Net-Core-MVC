using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class Tip
{
    public int Id { get; set; }

    public string? Tip1 { get; set; }

    public virtual ICollection<Ilan> Ilans { get; set; } = new List<Ilan>();
}
