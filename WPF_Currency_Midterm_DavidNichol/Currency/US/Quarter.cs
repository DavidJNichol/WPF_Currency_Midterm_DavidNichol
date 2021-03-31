using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public class Quarter : USCoin
    {
        public Quarter(USCoinMintMark MintMark)
        {
            this.MintMark = MintMark;
            MonetaryValue = .25M;
            this.Name = "Quarter";
        }

        public Quarter()
        {
            MonetaryValue = .25M;
            this.Name = "Quarter";
        }
    }
}
