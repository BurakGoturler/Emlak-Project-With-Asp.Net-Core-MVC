using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Emlak.Models;

public partial class EmlakContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=Emlak;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
}