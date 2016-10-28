using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph.Common
{
    public class Environment
    {
        private int _temp;

        public int Temp { get { return _temp; } }

        public Environment()
        {
            var random = new Random();

            _temp = random.Next(0, 10);
        }

        public void AdvanceEnvironment()
        {
            var random = new Random();
            _temp = random.Next(_temp - 3, _temp + 3);
        }

        public List<Biomorph> TestNewGen(List<Biomorph> nextGen)
        {
            foreach (var child in nextGen)
            {
                if (!child.TempRange.Contains(_temp))
                {
                    child.Alive = false;
                }
            }

            return nextGen;
        }
    }
}
