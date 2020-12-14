using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Models
{
    public class Context : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Email> Emails { get; set; }
        static Context()
        {
            Database.SetInitializer<Context>(new StoreDbInitializer());
        }
        public Context(string connectionString)
            : base(connectionString)
        {
        }
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context db)
        {
            db.Phones.Add(new Phone { Id = 1, PhoneNumber = "Nokia", PhoneNumberID = 220 });
            db.Phones.Add(new Phone { Id = 2, PhoneNumber = "Apple", PhoneNumberID = 320 });
            db.Phones.Add(new Phone { Id = 3, PhoneNumber = "lG", PhoneNumberID = 260 });
            db.Phones.Add(new Phone { Id = 4, PhoneNumber = "Samsung", PhoneNumberID = 300 });
            db.SaveChanges();
        }
    }
}
