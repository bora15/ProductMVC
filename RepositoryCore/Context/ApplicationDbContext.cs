using DomainCore.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryCore.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() : base("ProductsDB")
        {

        }

        public string ConnectionString { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
