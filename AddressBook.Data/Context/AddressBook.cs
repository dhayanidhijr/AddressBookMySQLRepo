using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using AddressBookDataLib.Model;
using AddressBookDataLib.Interface;

namespace AddressBookDataLib.Context
{
    public class AddressBook : DbContext, IDBContext<AddressBook>
    {

        protected IDatabaseSetting DatabaseSetting { get; set; }

        public AddressBook() { }

        public AddressBook(IDatabaseSetting databaseSetting)
        {
            this.DatabaseSetting = databaseSetting;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(DatabaseSetting.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactType>().HasData(Settings.DataInitializer.GetContactTypeSeedData());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<DreeItem> DreeItems { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Address> AddressList { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public AddressBook Context => this;
    }
}
