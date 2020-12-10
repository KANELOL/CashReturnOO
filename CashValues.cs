using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CashReturnCalculation
{
    class CashValues
    {
        public List<CashValue> _cashValues;
        private int[] _allowedValues;

        public CashValues()
        {
            _cashValues = new List<CashValue>()
            {
                new CashValue(1, true),
                new CashValue(5, true),
                new CashValue(10, true),
                new CashValue(20, true),
                new CashValue(50, false),
                new CashValue(100, false),
                new CashValue(200, false),
                new CashValue(500, false),
                new CashValue(1000, false),
            };
        }

        //public void fillCashValues(int amountOfValues)

        //{
        //    bool isCoin = true;
        //    if (amountOfValues <= _allowedValues.Length)
        //    {

        //        for (int i = 0; i < amountOfValues; i++)
        //        {
        //            if (_allowedValues[i] <= 20) isCoin = true;
        //            if (_allowedValues[i] > 20) isCoin = false;
        //            CashValue newValue = new CashValue(_allowedValues[i], isCoin);
        //            _cashValues.Add(newValue);
        //        }
        //    }
        //}

        public int[] GetAllowedValuesArray()
        {
            int[] newIntArray = new int[_cashValues.Count];
            for (int i = 0; i < _cashValues.Count; i++)
            {
                newIntArray[i] = _cashValues[i]._value;
            }
            return newIntArray;
        }
    }
}
