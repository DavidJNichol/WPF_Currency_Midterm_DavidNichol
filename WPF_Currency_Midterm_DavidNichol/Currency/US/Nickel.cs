using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Nickel : USCoin
    {
        public Nickel(USCoinMintMark MintMark)
        {
            this.MintMark = MintMark;
            MonetaryValue = .05M;
            this.Name = "Nickel";
            this.Portait = "Thomas Jefferson";
            this.ReverseMotif = "Monticello";
        }

        public Nickel() : this(USCoinMintMark.D)
        {
            MonetaryValue = .05M;
            this.Name = "Nickel";
            this.Portait = "Thomas Jefferson";
            this.ReverseMotif = "Monticello";
        }
    }
}
