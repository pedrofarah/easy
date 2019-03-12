using lib.dal;
using Microsoft.EntityFrameworkCore;

namespace UnitTestWebApi
{
    public static class DBContextPadrao
    {
        public static AppDbContext appDBContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: "baseTeste");

            return new AppDbContext(optionsBuilder.Options);
        }

        public static NucleoDados nucleoDados()
        {
            return new NucleoDados(appDBContext());
        }

    }
}
