using CQSSample.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CQSSample.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<UserEntity> Users { get; set; }
    }
}