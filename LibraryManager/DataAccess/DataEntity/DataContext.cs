using LibraryManager.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DataAccess.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryManager.DataAccess.DataEntity
{
    public class DataContext : IdentityDbContext<UserModel>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public virtual DbSet<RegisterBookModel> Tbl_RegisterBook { get; set; }

        public DbSet<RegisterBookDto> RegisterBookDto { get; set; }
    }
}