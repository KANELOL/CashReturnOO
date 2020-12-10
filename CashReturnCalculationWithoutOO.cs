using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashReturnCalculation
{
    class CashReturnCalculationWithoutOO
    {
        public static void Run()
        {
            
            //bool[] cashItemIsCoin = { true, true, true, true, false, false, false, false, false };
            CashValues cashValues = new CashValues();
            int[] cashItemValues = cashValues.GetAllowedValuesArray();
            Console.WriteLine("Allowed values: ");
            foreach (CashValue x in cashValues._cashValues)
            {
                Console.WriteLine($"{x._value} \n");
            }

            //var testArray = cashValues.GetAllowedValuesArray();
            //for (int i = 0; i < 9; i++)
            //{
            //    Console.WriteLine(testArray[i]+"\n");
            //}
            Console.WriteLine("Hvor mye skal det betales? ");
            var paymentAmountString = Console.ReadLine();
            var paymentAmount = Convert.ToInt32(paymentAmountString);
            var cashItemCounts = AcceptPayment(cashItemValues, paymentAmount);

            var paidAmount = SumAmount(cashItemCounts, cashItemValues);
            Console.WriteLine($"Du har betalt {paidAmount}kr.");
            var returnAmount = paidAmount - paymentAmount;
            ShowReturnAmount(returnAmount, cashItemValues);
        }

        private static void ShowReturnAmount(int returnAmount, int[] cashItemValues)
        {
            Console.WriteLine($"Du skal få tilbake {returnAmount}kr:");
            var remaining = returnAmount;
            foreach (var cashItemValue in cashItemValues.Reverse())
            {
                var count = remaining / cashItemValue;
                if (count > 0)
                {
                    remaining -= count * cashItemValue;
                    Console.WriteLine($" - {count}x{cashItemValue}kr");
                }
            }
        }

        private static int[] AcceptPayment(int[] cashItemValues, int paymentAmount)
        {
            var cashItemCounts = new int[9];
            var sumAmount = 0;
            do
            {
                Console.Write("Angi betaling (eks: 7x5kr betyr sju femkroner): ");
                var paymentString = Console.ReadLine();
                if (!paymentString.Contains("x") || !paymentString.EndsWith("kr")) continue;
                var xIndex = paymentString.IndexOf("x");
                var countString = paymentString.Substring(0, xIndex);
                var isSuccessCount = int.TryParse(countString, out int count);
                if (!isSuccessCount) continue;
                var cashItemString = paymentString.Substring(xIndex + 1).TrimEnd('k','r');
                var isSuccessCashItem = int.TryParse(cashItemString, out int cashItem);
                if (!isSuccessCashItem) continue;
                var cashItemIndex = Array.IndexOf(cashItemValues, cashItem);
                if (cashItemIndex == -1) continue;
                cashItemCounts[cashItemIndex] += count;
                sumAmount = SumAmount(cashItemCounts, cashItemValues);
                Console.WriteLine($"Du har betalt {sumAmount}kr.");
            } while (sumAmount < paymentAmount);

            return cashItemCounts;
        }

        public static int SumAmount(int[] countOfCashItem, int[] cashItemValues)
        {
            var sum = 0;
            for (var i = 0; i < countOfCashItem.Length; i++)
            {
                sum += countOfCashItem[i] * cashItemValues[i];
            }
            return sum;
        }
    }
}
