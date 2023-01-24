using Microsoft.EntityFrameworkCore;

namespace MultiPageAppApierce.Models
{
    public class ContactContext : DbContext
    {

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Jack Burton",
                    PhoneNumber = "5558675309",
                    Address = "Visalia, California",
                    Note = "Everybody relax, I'm here."
                },
                new Contact
                {
                    ContactId = 2,
                    Name = "Ellen Ripley",
                    PhoneNumber = "9035768555",
                    Address = "Olympia Colony, Luna",
                    Note = "This is commercial towing vehicle Nostromo out of the Solomons, registration number 1-8-0-niner-2-4-6-0-niner."
                },
                new Contact
                {
                    ContactId = 3,
                    Name = "Korben Dallas",
                    PhoneNumber = "C4765536",
                    Address = "West Park Alleys 281 Level 21 / PIER 23-28 HA CON 37 / 144E NY, NY 10024",
                    Note = "Negative, I am a meat popsicle."
                }

            ); ;
        }
    }
}

