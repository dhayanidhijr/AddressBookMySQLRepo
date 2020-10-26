using System.Collections.Generic;
using AddressBookDataLib.Model;
using DataInterface = AddressBookDataLib.Interface;

namespace AddressBookBusinessLib.DataMap
{
    public abstract class DreeItem<FromDataObject> : Common.DataMapper<FromDataObject> 
        where FromDataObject : DataInterface.IDataObject
    {
        public int Id
        {
            get
            {
                return (int)this.GetProperty("Id");
            }
            set
            {
                this.SetProperty("Id", value);
            }
        }

        public string Data
        {
            get
            {
                return (string)this.GetProperty("Data");
            }
            set
            {
                this.SetProperty("Data", value);
            }
        }

        public DreeItem Branches
        {
            get
            {
                return (DreeItem)this.GetProperty("Branches");
            }
            set
            {
                this.SetProperty("Branches", value);
            }
        }
    }
}
