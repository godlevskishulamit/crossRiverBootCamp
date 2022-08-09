namespace CoronaApp.Dal.Models;

public class CoronaContext : DbContext
{
    public CoronaContext()
    {

    }
    public CoronaContext(DbContextOptions<CoronaContext> options) : base(options)
    {

    }
    public virtual DbSet<Patient> Patient { get; set; }
    public virtual DbSet<Location> Location { get; set; }
    public DbSet<Log> Log { get; set; }
    public virtual DbSet<User>? User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-R5RADSP;Database=Corona;Trusted_Connection=True;");
        //optionsBuilder.UseSqlServer(_configurtion.GetSection("ConnectionStrings")["CoronaConnection"]);
    }
}
