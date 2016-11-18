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
        private List<Biomorph> _offspring;
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

        public List<Biomorph> Offspring { get { return _offspring; } }

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
        public void GenerateWorld()
        {
            _bio = new Biomorph();
            _opponent = new Biomorph();
            _environment = new Environment();
        }

        /// <summary>
        /// Advances the World to the Next Generation
        /// </summary>
        /// <returns>list of child Biomorphs for Artificial Selection</returns>
        public List<Biomorph> NextGeneration()
        {
            var children = _bio.GenerateNextGen();

            var oChildren = _opponent.GenerateNextGen();

            _environment.AdvanceEnvironment();

            _opponent = NatuarlySelectBio(oChildren);

            foreach (var child in children)
            {
                child.ScoreCombat(_opponent);
            }

            _offspring = _environment.TestNewGen(children);

            return _offspring;
        }

        public void TestCurrentGen()
        {
            Bio.ScoreCombat(Opponent);
            Opponent.ScoreCombat(Bio);
            _environment.TestCurrentGen(Bio);
            _environment.TestCurrentGen(Opponent);

        }

        /// <summary>
        /// Sets the Biomorph selected by user to main new BIO
        /// </summary>
        /// <param name="biomorph">Artifically Selected Biomorph</param>
        public void ArtificalySelectedBio(Biomorph biomorph)
        {
            _bio = biomorph;
        }

        /// <summary>
        /// Uses natural selection to determin which Opponetn Child is best against Previons Biomorph
        /// </summary>
        /// <param name="oChildren">Offspring of Opponent</param>
        /// <returns>Naturally sellected opponent child</returns>
        private Biomorph NatuarlySelectBio(List<Biomorph> oChildren)
        {
            foreach (var child in oChildren)
            {
                child.ScoreCombat(_bio);
            }

            oChildren = _environment.TestNewGen(oChildren);

            var selected = oChildren.Where(child => child.Alive).OrderBy(child => child.CombatScore).FirstOrDefault();

            return selected == default(Biomorph) ? oChildren.OrderBy(child => child.CombatScore).FirstOrDefault() : selected;
        }
    }
}
