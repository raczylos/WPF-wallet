using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallet_project_WPF {
    public class WalletContext : DbContext{
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=wallets.db");
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
