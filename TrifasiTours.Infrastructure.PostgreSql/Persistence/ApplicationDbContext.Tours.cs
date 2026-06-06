using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifasiTours.Domain.Tours;
using Microsoft.EntityFrameworkCore;

namespace TrifasiTours.Infrastructure.PostgreSql.Persistence;

public partial class ApplicationDbContext
{
    public virtual DbSet<Tour> Tours { get; set; }
}
