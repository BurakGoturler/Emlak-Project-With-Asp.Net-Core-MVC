using Emlak.MetaData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emlak.Models;

[ModelMetadataType(typeof(IlanMetaData))]
public partial class Ilan
{
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}