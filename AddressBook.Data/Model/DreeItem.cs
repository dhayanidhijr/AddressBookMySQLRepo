using System.Collections.Generic;
using AddressBookDataLib.Common;
using System.ComponentModel.DataAnnotations;

namespace AddressBookDataLib.Model
{

    public class DreeItem : DataObject
    {
        [Key]
        public int Id { get; set; }

        public string Data { get; set; }

        public ICollection<DreeItem> Branches { get; set; }
    }
}
