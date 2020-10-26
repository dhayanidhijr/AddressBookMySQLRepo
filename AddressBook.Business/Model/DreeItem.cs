using DataModel = AddressBookDataLib.Model;
namespace AddressBookBusinessLib.Model
{
    public class DreeItem : DataMap.DreeItem<DataModel.DreeItem>
    {

        public DreeItem()
        {
            InitializeData(new DataModel.DreeItem());
        }

        private DreeItem(DataModel.DreeItem dreeItem)
        {
            InitializeData(dreeItem);
        }

        private void InitializeData(DataModel.DreeItem dreeItem)
        {
            base.DataObject = dreeItem;
        }


        public static implicit operator DreeItem(DataModel.DreeItem dreeItem)
        {
            if (dreeItem == null) return null;
            return new DreeItem(dreeItem);
        }
    }
}
