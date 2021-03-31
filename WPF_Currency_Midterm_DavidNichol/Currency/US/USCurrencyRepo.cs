using System;
using System.Collections.Generic;
using Currency.US;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    [Serializable]
    public class USCurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }
        public string about { get; set; }
        public ICurrencyRepo changeRepo { get; set; }
        public decimal amount { get; set; }

        
        public USCurrencyRepo()
        {
            Coins = new List<ICoin>();
            about = About();
            changeRepo = MakeChange(0,this);
        }

        public string About()
        {
            string coinNames = "";

            foreach(ICoin c in Coins)
            {
                coinNames += " " + c.Name;
            }

            about = coinNames;
            return coinNames;
        }

        public void AddCoin(ICoin c)
        {
            Coins.Add(c);
        }

        public int GetCoinCount()
        {
            return Coins.Count;
        }

        public static ICurrencyRepo MakeChange(decimal Amount, ICurrencyRepo currencyRepo)
        {
            if (Amount < .05M)
            {
                for (int i = 1; i < Math.Ceiling(Amount * 100); i++)
                {
                    currencyRepo.Coins.Add(new Penny());                    
                }
            }
            if ((Amount % 1M) < Amount)
            {
                for (int i = 0; i < (int)Amount; i++)
                {
                    currencyRepo.Coins.Add(new DollarCoin());
                }
                Amount %= 1;
            }
            if (Amount % .5M < Amount)
            {
                for (int i = 0; i < (int)Amount + .5M; i++)
                {
                    currencyRepo.Coins.Add(new HalfDollar());

                }
                Amount %= .5M;
            }
            if (Amount % .25M < Amount)
            {
                for (int i = 0; i < (int)Amount + .25M; i++)
                {
                    currencyRepo.Coins.Add(new Quarter());
                }
                Amount %= .25M;
            }
            if (Amount % .1M < Amount)
            {
                for (int i = 0; i < (int)Amount + .1M; i++)
                {
                    currencyRepo.Coins.Add(new Dime());
                }
                Amount %= .1M;
            }
            if (Amount % .05M < Amount)
            {
                for (int i = 0; i < (int)Amount + .05M; i++)
                {
                    currencyRepo.Coins.Add(new Nickel());
                }
                Amount %= .05M;
            }
            if (Amount % .01M < Amount)
            {
                for (int i = 0; i < (int)Amount + .01M; i++)
                {
                    currencyRepo.Coins.Add(new Penny());
                }
                Amount %= .01M;
            }          

            return currencyRepo;
        }

        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            return this;
        }

        public ICoin RemoveCoin(ICoin c)
        {
            Coins.Remove(c);
            return c;
        }

        public decimal TotalValue()
        {
            decimal total = 0;
            foreach (ICoin c in Coins)
            {
                total += c.MonetaryValue;
            }

            amount = total;
            return total;
        }
    }
}
