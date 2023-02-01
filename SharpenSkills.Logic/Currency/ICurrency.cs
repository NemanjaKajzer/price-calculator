using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenSkills.Logic
{
    public interface ICurrency
    {
        string IsoCode { get; set; }
        string Symbol { get; set; }
    }
}
