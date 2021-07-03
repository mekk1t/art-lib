using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Database
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            if (args.Length == 0)
                throw new Exception("Не указаны аргументы командной строки.");

            Console.WriteLine("Аргументы командной строки:");
            foreach (var arg in args)
                Console.WriteLine(arg);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(args[0]);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
