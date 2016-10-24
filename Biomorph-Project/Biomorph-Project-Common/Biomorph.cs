using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph_Project_Common
{
    public class Biomorph : IBiomorph
    {
        private int _minTemp;
        private int _maxTemp;
        private int _strength;
        private int _intel;
        private int _camo;
        private int _vision;

        public int MinTemp
        {
            get
            {
                return this._minTemp;
            }
        }

        public int MaxTemp
        {
            get
            {
                return this._maxTemp;
            }
        }

        public int Strength
        {
            get
            {
                return this._strength;
            }
        }

        public int Intel
        {
            get
            {
                return this._intel;
            }
        }

        public int Camo
        {
            get
            {
                return this._camo;
            }
        }

        public int Vision
        {
            get
            {
                return this._vision;
            }
        }

        public Biomorph(int minTemp, int maxTemp, int strength, int intel, int camo, int vision)
        {
            _minTemp = minTemp;
            _maxTemp = maxTemp;
            _strength = strength;
            _intel = intel;
            _camo = camo;
            _vision = vision;
        }

        /// <summary>
        /// Calculates the scores of BioMorph vz Opponent
        /// </summary>
        /// <param name="oponent"></param>
        /// <returns></returns>
        public int CombatScore(IBiomorph oponent)
        {
            var scores = new List<int>();
            scores.Add(Scorer(_strength, oponent.Strength));
            scores.Add(Scorer(_intel, oponent.Intel));
            scores.Add(Scorer(_camo, oponent.Camo));
            scores.Add(Scorer(_vision, oponent.Vision));

            if (scores.Any(x => x < 0))
            {
                return 0;
            }

            return scores.Sum();
        }

        private int Scorer(int bioScore, int oponentScore)
        {
            return bioScore - oponentScore;
        }
    }
}
