using Core.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.API.DataAccess.SqlAccess;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Candidate> Candidates { get; set; }

}