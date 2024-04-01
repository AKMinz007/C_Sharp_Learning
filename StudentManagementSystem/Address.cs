using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Address
    {
        private string _addressLine1;
        private string _post;
        private string _block;
        private string _district;
        private string _state;
        private int _pinCode;

        public string _AddressLine1
        { 
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }
        public string _Post
        {
            get { return _post; }
            set { _post = value; }

        }
       
        public string _Block
        {
            get { return _block; }
            set { _block = value; }
        }

        public string _District
        {
            get { return _district; }
            set { _district = value; }
        }

        public string _State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int _PinCode
        {
            get { return _pinCode; }
            set { _pinCode = value; }
        }


    }
}
