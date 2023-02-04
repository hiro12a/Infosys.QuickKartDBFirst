using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public class ProductCategoryName
    {
        [Key]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int QuantityAvailable { get; set; }

        /*public class LoginDetails
        {
            public string EmailId { get; set; }
            public DateTime LoginDate { get; set; }
            public DateTime LoginTime { get; set; }
            public string BrowseOrPurchase { get; set; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDetails>()
                .HasKey(Id = new { Id.EmailId, Id.LoginDate, Id.LoginTime })
                .HasName("pk_LoginDetails");
        }*/
    }
}
