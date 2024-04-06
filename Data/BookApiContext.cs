using Microsoft.EntityFrameworkCore;

namespace livraria_dotnetcore_webapi.Data
{
    public class BookApiContext : DbContext
    {
        public BookApiContext(DbContextOptions<BookApiContext> options): base(options) { }

        public DbSet<Entities.Book> Books { get; set; }
    }
}
