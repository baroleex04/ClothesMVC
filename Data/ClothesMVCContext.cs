using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothesMVC.Models;

namespace ClothesMVC.Data
{
    public class ClothesMVCContext : DbContext
    {
        public ClothesMVCContext (DbContextOptions<ClothesMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ClothesMVC.Models.Clothes> Clothes { get; set; } = default!;
    }
}
