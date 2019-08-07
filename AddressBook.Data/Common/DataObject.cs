﻿using System;
using System.Collections.Generic;
using System.Text;
using AddressBookDataLib.Interface;

namespace AddressBookDataLib.Common
{
    public abstract class DataObject : IDataObject
    {

        public DataObject()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
            Active = 1;
        }

        public void UpdateTime()
        {
            Updated = DateTime.Now;
        }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Active { get; set; }
    }
}
