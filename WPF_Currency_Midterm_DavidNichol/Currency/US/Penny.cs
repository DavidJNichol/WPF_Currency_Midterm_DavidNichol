using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Penny : USCoin
    {
        public Penny(USCoinMintMark MintMark)
        {
            this.MintMark = MintMark;
            MonetaryValue = .01M;
            this.Name = "Penny";
            this.ReverseMotif = "Union shield";
            this.Portait = "Abraham Lincoln";
        }

        public Penny() 
        {
            MonetaryValue = .01M;
            this.Name = "Penny";
            this.ReverseMotif = "Union shield";
            this.Portait = "Abraham Lincoln";
        }
    }
}
