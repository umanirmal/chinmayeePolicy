using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChinmayeePolicy
{
    public partial class d46u65jgu6o7g0Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=ec2-54-243-63-13.compute-1.amazonaws.com;Database=d46u65jgu6o7g0;Username=omdcyfxildwgvt;Password=6e5b3c77d3402669530985e7ed46aa6c5edbf441b588931b19b1769493207d3a;SSL Mode=Require;Trust Server Certificate=True;Use SSL Stream=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}
    }
}
