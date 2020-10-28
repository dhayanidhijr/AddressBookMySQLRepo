
using System.Collections.Generic;
using AddressBookBusinessLib.Model;
using Microsoft.Extensions.Logging;
using System.Linq;
using DataModel = AddressBookDataLib.Model;
using DataInterface = AddressBookDataLib.Interface;
using BusinessModel = AddressBookBusinessLib.Model;
using BusinessInterface = AddressBookBusinessLib.Interface;
using AddressBookBusinessLib.Interface;

namespace AddressBookBusinessLib.Repository
{
    public class DreeItemRepository : BusinessInterface.IDreeItemRepository
    {

        DataInterface.IDreeItemRepository dreeItemRepository;
        ILogger<DreeItemRepository> logger;

        public DreeItemRepository(ILogger<DreeItemRepository> logger, DataInterface.IDreeItemRepository dreeItemRepository)
        {
            this.dreeItemRepository = dreeItemRepository;
            this.logger = logger;
        }

        public bool Create(DreeItem model)
        {
            return dreeItemRepository.Create(model.DataObject);
        }

        public bool Delete(int key)
        {
            return dreeItemRepository.Delete(key);
        }

        public DreeItem Read(int key)
        {
            return dreeItemRepository.Read(key);
        }

        public IEnumerable<DreeItem> ReadAll()
        {
            var result = dreeItemRepository.ReadAll().Select((item) =>
            {
                return (BusinessModel.DreeItem)item;
            });

            return result;
        }

        public bool Update(DreeItem model)
        {
            return dreeItemRepository.Update(model.DataObject);
        }
    }
}
