using Microsoft.EntityFrameworkCore;
using wsb_app.Persistance.Models.Customers;

namespace wsb_app.Data;

public class CrmDbContext : DbContext
{
    public string DbPath { get; }

    public CrmDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "userDatabase.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
