using System;
using System.Collections.Generic;
using System.Text;

namespace CashReturnCalculation
{
    class CashValue
    {
        public int _value;
        private bool _isCoin;

        public CashValue(int value, bool isCoin)
        {
            _value = value;
            _isCoin = isCoin;
        }
    }

}
