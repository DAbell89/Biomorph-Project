using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biomorph.Common
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
            get { return this._minTemp; }
        }

        public int MaxTemp
        {
            get { return this._maxTemp; }
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

        public Biomorph()
        {
            var random = new Random();

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
        /// Initializes a child based of a parent Biomorph
        /// </summary>
        /// <param name="parent">Parent Biomorph</param>
        public Biomorph(Biomorph parent)
        {
            var random = new Random();

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
    public int CombatScore(IBiomorph oponent)
    {
        var scores = new List<int>();
        scores.Add(Scorer(_strength, oponent.Strength));
        scores.Add(Scorer(_intel, oponent.Intel));
        scores.Add(Scorer(_camo, oponent.Camo));
        scores.Add(Scorer(_vision, oponent.Vision));

        return scores.Sum();
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
