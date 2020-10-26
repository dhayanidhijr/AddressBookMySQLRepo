using AddressBookDataLib.Model;
using AddressBookDataLib.Settings;

namespace AddressBookDataLib.Interface
{
    public interface IDreeItemRepository :
        IDataSetRepository<DreeItem, int>,
        IRepository<IDatabaseSetting> { }
}
