using livraria_dotnetcore_webapi.Entities.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace livraria_dotnetcore_webapi.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public EBookGenres Genre { get; set; }
        public double Price { get; set; }
        public short Stock { get; set; }


    }
}
