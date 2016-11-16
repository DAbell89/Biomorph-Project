using Biomorph.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biomorph_Web.Models
{
    public class WorldViewModel
    {
        public BiomorphViewModel Bio { get; set; }
        public List<BiomorphViewModel> Offspring { get; set; }
        public BiomorphViewModel Opponent { get; set; }
        public EnvironmentViewModel Environment { get; set; }

    }
}