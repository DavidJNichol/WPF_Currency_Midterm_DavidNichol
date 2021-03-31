using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency
{
    public interface ICurrencyRepo
    {
        List<ICoin> Coins { get; set; }
        string About();
        void AddCoin(ICoin c);
        int GetCoinCount();
        ICoin RemoveCoin(ICoin c);
        decimal TotalValue();
    }
}
