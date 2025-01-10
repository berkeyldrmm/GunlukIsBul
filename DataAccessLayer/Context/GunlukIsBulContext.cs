using DataAccessLayer.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;

namespace DataAccessLayer.Context
{
    public class GunlukIsBulContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Ilan> Ilanlar { get; set; }
        public virtual DbSet<IsKategori> IsKategoriler { get; set; }

        //public GunlukIsBulContext(DbContextOptions<GunlukIsBulContext> options) : base(options)
        //{

        //}

        public GunlukIsBulContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gunlukisbul.db");
        }
    }
}
