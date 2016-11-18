using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph.Common
{
    public class Biomorph
    {
        private bool _alive;
        private int _minTemp;
        private int _maxTemp;
        private int _strength;
        private int _intel;
        private int _camo;
        private int _vision;
        private int _combatScore;
        private static Random random = new Random();

        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }

        public int MinTemp
        {
            get { return this._minTemp; }
        }

        public int MaxTemp
        {
            get { return this._maxTemp; }
        }

        public IEnumerable<int> TempRange
        {
            get
            {
                var range = new List<int>();
                for (int i = _minTemp; i <= _maxTemp; i++)
                {
                    range.Add(i);
                }
                return range;
            }
        }

        public int Strength
        {
            get { return this._strength; }
        }

        public int Intel
        {
            get { return this._intel; }
        }

        public int Camo
        {
            get { return this._camo; }
        }

        public int Vision
        {
            get { return this._vision; }
        }

        public int CombatScore { get { return _combatScore; } }

        public Biomorph()
        {
            _alive = true;
            _minTemp = random.Next(0, 10);
            _maxTemp = random.Next(0, 10);
            _strength = random.Next(0, 10);
            _intel = random.Next(0, 10);
            _camo = random.Next(0, 10);
            _vision = random.Next(0, 10);

            if (_minTemp > _maxTemp)
            {
                _maxTemp = _minTemp + 1;
            }
        }

        /// <summary>
        /// Creates Biomorph with specified inputs
        /// </summary>
        /// <param name="alive">Alive Property</param>
        /// <param name="mintemp">Minimum Temperature Property</param>
        /// <param name="maxtemp">Maximum Temperature  Property</param>
        /// <param name="strenght">Strenght Property</param>
        /// <param name="intel">Inteligence Property</param>
        /// <param name="camo">Camoflague Property</param>
        /// <param name="vision">Vision Property</param>
        /// <param name="combatScore">Combat Score Property</param>
        public Biomorph(bool alive, int mintemp, int maxtemp, int strenght, int intel, int camo, int vision, int combatScore)
        {
            _alive = alive;
            _minTemp = mintemp;
            _maxTemp = maxtemp;
            _strength = strenght;
            _intel = intel;
            _camo = camo;
            _vision = vision;
            _combatScore = combatScore;
        }

        /// <summary>
        /// Initializes a child based of a parent Biomorph
        /// </summary>
        /// <param name="parent">Parent Biomorph</param>
        public Biomorph(Biomorph parent)
        {
            var random = new Random();

            _alive = true;
            _minTemp = random.Next(parent.MinTemp - 5, parent.MinTemp + 5);
            _maxTemp = random.Next(parent.MaxTemp - 5, parent.MaxTemp + 5);
            _strength = random.Next(parent.Strength - 5, parent.Strength + 5);
            _intel = random.Next(parent.Intel - 5, parent.Intel + 5);
            _camo = random.Next(parent.Camo - 5, parent.Camo + 5);
            _vision = random.Next(parent.Vision - 5, parent.Vision + 5);

            if (_minTemp > _maxTemp)
            {
                _maxTemp = _minTemp + 1;
            }
        }

        /// <summary>
        /// Generates 5 offspring for the next generation with mutated states based off the parent
        /// </summary>
        /// <returns>5 offspring</returns>
        public List<Biomorph> GenerateNextGen()
        {
            var offspring = new List<Biomorph>();

            while (offspring.Count < 5)
            {
                offspring.Add(new Biomorph(this));
            }


            return offspring;
        }

        /// <summary>
        /// Calculates the scores of BioMorph vz Opponent and returns a total score
        /// </summary>
        /// <param name="oponent"></param>
        /// <returns></returns>
        public int ScoreCombat(Biomorph oponent)
        {
            var scores = new List<int>();
            scores.Add(Scorer(_strength, oponent.Strength));
            scores.Add(Scorer(_intel, oponent.Intel));
            scores.Add(Scorer(_camo, oponent.Camo));
            scores.Add(Scorer(_vision, oponent.Vision));
            var finalScore = scores.Sum();

            if (finalScore < -50)
            {
                _alive = false;
            }

            _combatScore = finalScore;

            return finalScore;
        }

        /// <summary>
        /// Calculates the difference between scores
        /// </summary>
        /// <param name="bioScore">Biomorph's Score</param>
        /// <param name="oponentScore">Oponent's score</param>
        /// <returns>Difference between scores</returns>
        private int Scorer(int bioScore, int oponentScore)
        {
            return bioScore - oponentScore;
        }
    }
}
