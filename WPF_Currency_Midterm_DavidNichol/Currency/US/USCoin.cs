using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Currency.US
{
    [Serializable]
    public abstract class USCoin : Coin
    {

        public USCoinMintMark MintMark  { get; set; }

        public USCoin()
        {
            MintMark = USCoinMintMark.D; // Default D
            this.Year = System.DateTime.Now.Year;
            this.Name = "Dollar";
            this.Portait = "";
            this.ReverseMotif = "";
        }

        public USCoin(USCoinMintMark MintMark)
        {
            this.MintMark = MintMark;
        }

        /// <summary>
        /// Tells informatrion about  a US Coin
        /// </summary>
        /// <returns></returns>
        public override string About()
        {
            string strAbout = $"{this.Name} is from { System.DateTime.Now.Year }. It is worth ${MonetaryValue}. It was made in {GetMintNameFromMark(MintMark)}";
            
            return "US " + strAbout;
        }

        /// <summary>
        /// Returns the full name of a coind Mint Mark
        /// </summary>
        /// <param name="MintMark"></param>
        /// <returns>Full Mint Namt</returns>
        public static string GetMintNameFromMark(USCoinMintMark MintMark)
        {
            string MintName = "";

            if (MintMark == USCoinMintMark.D)
            {
                MintName = "Denver";
            }
            else if(MintMark == USCoinMintMark.P)
            {
                MintName = "Philadelphia";
            }
            else if (MintMark == USCoinMintMark.S)
            {
                MintName = "San Francisco";
            }
            else
            {
                MintName = "West Point";
            }

            return MintName;
        }

        public static List<ICoin> GetUSCoinList()
        {
            List<ICoin> coinList = new List<ICoin>()
            {
                new DollarCoin(),
                new HalfDollar(),
                new Quarter(),
                new Dime(),
                new Nickel(),
                new Penny(),
            };

            return coinList;

        }

    }

    public enum USCoinMintMark
    {
        P, D, S, W
    }
}
