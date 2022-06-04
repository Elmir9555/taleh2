using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendLahiye.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendLahiye.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetails> BlogDetails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<SaleOff> SaleOffs { get; set; }
        public DbSet<SaleOffDetails> SaleOffDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Subcribe> Subcribes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
