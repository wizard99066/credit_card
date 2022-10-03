using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit_card
{
    internal class cr_card
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler? Notify;

        public cr_card(int sum) => Sum = sum;
        public int Sum { get; private set; }

        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"Received on account: {sum},Current balance: {Sum}");
        }

        public void Get(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Withdrawn from account: {sum},Current balance: {Sum}");
            }
            else
            {
                Notify?.Invoke($"Not enough money in the account.Current balance:{Sum}");
            }
        }
    }
}
