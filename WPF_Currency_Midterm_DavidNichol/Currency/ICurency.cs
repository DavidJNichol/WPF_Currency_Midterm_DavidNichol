using System;
using System.Collections.Generic;
using System.Text;

namespace Currency
{
    public interface ICurrency
    {
        decimal MonetaryValue { get; set; }

        string Name { get; set; }

        string About();

        string Portait { get; }
        string ReverseMotif { get; }
    }
}
