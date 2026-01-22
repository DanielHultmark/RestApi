using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Data
{
    public class RestApiDbContext : DbContext
    {
        public RestApiDbContext(DbContextOptions<RestApiDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Intrest>().HasData(
                new Intrest { Id = 1, Name = "Fotografi", Description = "Att ta och redigera bilder." },
                new Intrest { Id = 2, Name = "Löpning", Description = "Träning och tävling inom långdistans." },
                new Intrest { Id = 3, Name = "Matlagning", Description = "Experimentera med recept och råvaror." },
                new Intrest { Id = 4, Name = "Gaming", Description = "Spela spel på PC och konsol." },
                new Intrest { Id = 5, Name = "Resor", Description = "Utforska nya platser och kulturer." }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Anna", LastName = "Svensson", PhoneNr = "0701234567", Email = "anna.svensson@example.com" },
                new Person { Id = 2, FirstName = "Johan", LastName = "Lindberg", PhoneNr = "0739876543", Email = "johan.lindberg@example.com" },
                new Person { Id = 3, FirstName = "Sara", LastName = "Ekström", PhoneNr = "0765551122", Email = "sara.ekstrom@example.com" },
                new Person { Id = 4, FirstName = "Daniel", LastName = "Hultmark", PhoneNr = "0707654321", Email = "daniel.hultmark@example.com" },
                new Person { Id = 5, FirstName = "Mikael", LastName = "Berg", PhoneNr = "0729988776", Email = "mikael.berg@example.com" }
            );

            modelBuilder.Entity<PersonIntrest>().HasData(
                new PersonIntrest { Id = 1, PersonId = 1, IntrestId = 1 },
                new PersonIntrest { Id = 2, PersonId = 1, IntrestId = 3 },
                new PersonIntrest { Id = 3, PersonId = 2, IntrestId = 2 },
                new PersonIntrest { Id = 4, PersonId = 3, IntrestId = 5 },
                new PersonIntrest { Id = 5, PersonId = 4, IntrestId = 4 },
                new PersonIntrest { Id = 6, PersonId = 5, IntrestId = 1 }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://example.com/fotografi-guide", PersonId = 1, IntrestId = 1 },
                new Link { Id = 2, Url = "https://example.com/matlagning-recept", PersonId = 1, IntrestId = 3 },
                new Link { Id = 3, Url = "https://example.com/lopning-tips", PersonId = 2, IntrestId = 2 },
                new Link { Id = 4, Url = "https://example.com/resor-blogg", PersonId = 3, IntrestId = 5 },
                new Link { Id = 5, Url = "https://example.com/gaming-nyheter", PersonId = 4, IntrestId = 4 },
                new Link { Id = 6, Url = "https://example.com/fotografi-nyborjare", PersonId = 5, IntrestId = 1 }
            );

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Intrest> Intrests { get; set; }
        public DbSet<PersonIntrest> PersonIntrests { get; set; }
        public DbSet<Link> Links { get; set; }
    }   
}
