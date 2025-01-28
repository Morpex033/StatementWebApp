using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StatementWebApp.Persistence.Context;

public class CustomDbContextFactory : IDesignTimeDbContextFactory<CustomDbContext>
{
    public CustomDbContext CreateDbContext(string[] args)
    {
        var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "StatementWebApp.API");
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(path)
            .AddJsonFile("appsettings.json")
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<CustomDbContext>();
        
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new CustomDbContext(optionsBuilder.Options);
    }
}