using System;
using System.Collections.Generic;

namespace Emlak.Models;

public partial class SoruCevap
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Soru { get; set; }

    public DateTime? Tarih { get; set; }

    public string? Cevap { get; set; }
}
