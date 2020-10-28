using System.Collections.Generic;
using AddressBookDataLib.Interface;
using AddressBookDataLib.Model;
using AddressBookDataLib.Context;
using Microsoft.EntityFrameworkCore;
using AddressBookDataLib.Common;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AddressBookDataLib.Repository
{
    public class DreeItemRepository : IDreeItemRepository
    {

        AddressBook addressBook;
        public ILogger Logger { get; set; }
        public IDatabaseSetting Settings { get; set; }

        public DreeItemRepository(ILogger<DreeItemRepository> logger, IDatabaseSetting settings, IDBContext<AddressBook> dbContext)
        {
            this.Logger = logger;
            this.Settings = settings;
            addressBook = dbContext.Context;
        }

        public bool Create(DreeItem model)
        {
            addressBook.DreeItems.Add(model);
            return (addressBook.SaveChanges() >= 0);
        }

        public bool Delete(int key)
        {
            addressBook.DreeItems.Remove(
                addressBook.DreeItems.SingleOrDefault((item) => item.Id == key)
            );
            return addressBook.SaveChanges().Equals(1);
        }

        public DreeItem Read(int key)
        {
            return addressBook
                .DreeItems
                .Include((item) => item.Branches)
                    .SingleOrDefault((item) => item.Id == key);
        }

        public IEnumerable<DreeItem> ReadAll()
        {
            return addressBook.DreeItems
                .Include((item) => item.Branches)
                .Where((item) => item.Active == 1);
        }

        public bool Update(DreeItem model)
        {
            DreeItem dreeItem = addressBook.DreeItems.SingleOrDefault((item) => item.Id == model.Id);
            if (dreeItem == null) return false;
            //  model.Branches = addressBook.DreeItems.SingleOrDefault((item) => item.Id == model.Branches);
            dreeItem.Data = model.Data.GetOrDefault(dreeItem.Data);
            dreeItem.UpdateTime();
            addressBook.DreeItems.Update(dreeItem);
            return addressBook.SaveChanges().Equals(1);
        }
    }
}
