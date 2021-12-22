using Bank.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bank.Data
{
    public class BankDbContext
    : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
        : base(options)
        {
            
        }


        public DbSet<Account> Account { get; set; }
        public DbSet<Account> Address { get; set; }
        public DbSet<Account> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Address>().HasData(

                new Address { Id = 1, Street = "Partizanska", City="Skopje" , Country ="Macedonia"},
                new Address { Id = 1, Street = "Solunska", City= "Skopje", Country = "Macedonia" }
                
               
                );

            mb.Entity<Client>().HasData
             (

                new Client
                {
                    Id = 1,
                    Name = "Matej",
                    PhoneNumber = "075778987",
                    Email = "MatejPetrovski@gmail.com",
                   
                   
                },

               

               

                new Client
                {
                    Id = 2,
                    Name = "John",
                    PhoneNumber = "075889878",
                    Email = "Hastings@gamil.com",
                });




        }



    }
}
