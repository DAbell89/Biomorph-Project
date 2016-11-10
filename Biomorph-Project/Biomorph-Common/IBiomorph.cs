using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph.Common
{
    public interface IBiomorph
    {
        int MinTemp { get; }
        int MaxTemp { get; }
        int Strength { get; }
        int Intel { get; }
        int Camo { get; }
        int Vision { get; }

        int ScoreCombat(IBiomorph oponent);
    }
}
