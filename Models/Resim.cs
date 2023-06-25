using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class Resim
{
    public int Id { get; set; }

    public string? Resim1 { get; set; }

    public int? IlanId { get; set; }

    public virtual Ilan? Ilan { get; set; }
}
