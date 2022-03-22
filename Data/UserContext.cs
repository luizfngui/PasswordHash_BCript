using Microsoft.EntityFrameworkCore;
using PasswordHash_BCript.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordHash_BCript.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base (opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
