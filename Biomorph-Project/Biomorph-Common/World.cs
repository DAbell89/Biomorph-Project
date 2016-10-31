using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph.Common
{
    public class World
    {
        private Biomorph _bio;
        private Biomorph _opponent;
        private Environment _environment;

        public Biomorph Bio
        {
            get
            {
                return _bio;
            }

            set
            {
                _bio = value;
            }
        }

        public Biomorph Opponent
        {
            get
            {
                return _opponent;
            }

            set
            {
                _opponent = value;
            }
        }

        public Environment Environment
        {
            get
            {
                return _environment;
            }

            set
            {
                _environment = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of a World
        /// </summary>
        public World()
        {
            _bio = new Biomorph();
            _opponent = new Biomorph();
            _environment = new Environment();
        }
    }
}
