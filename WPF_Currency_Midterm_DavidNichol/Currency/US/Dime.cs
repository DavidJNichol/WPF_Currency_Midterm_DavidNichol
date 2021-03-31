using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Dime : USCoin
    {
        public Dime(USCoinMintMark MintMark)
        {
            this.MintMark = MintMark;
            MonetaryValue = .10M;
            this.Name = "Dime";
            this.Portait = "Franklin D. Roosevelt";
            this.ReverseMotif = "torch, oak branch, olive branch";
        }

        public Dime() 
        {
            MonetaryValue = .10M;
            this.Name = "Dime";
            this.Portait = "Franklin D. Roosevelt";
            this.ReverseMotif = "torch, oak branch, olive branch";
        }
    }
}
