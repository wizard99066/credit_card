using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace credit_card
{
    public class CreditCard
    {
        public delegate void AccountAction(string message);
        AccountAction? taken;

        public CreditCard(int sum) => Sum = sum;
        public int Sum { get; private set; }

        public void RegisterHandler(AccountAction del) => taken = del;

        public void Put(int sum)
        {
            Sum += sum;
            taken?.Invoke($"Received on account: {sum},Current balance: {Sum}");
        }

        public void Get(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                taken?.Invoke($"Withdrawn from account: {sum},Current balance: {Sum}");
            }
            else
            {
                taken?.Invoke($"Not enough money in the account.Current balance:{Sum}");
            }
        }
    }
}
