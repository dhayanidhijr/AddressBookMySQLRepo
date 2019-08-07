using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookDataLib.Interface
{
    public interface IDataObject
    {
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
        int Active { get; set; }

    }
}
