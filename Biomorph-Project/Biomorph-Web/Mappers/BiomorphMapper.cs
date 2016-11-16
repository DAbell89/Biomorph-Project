using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biomorph_Web.Mappers
{
    public class BiomorphMapper
    {
        /// <summary>
        /// Maps a BiomorphViewModel to a Biomorph Model
        /// </summary>
        /// <param name="viewModel">ViewModel to be Mapped</param>
        /// <returns>Biomorph Model</returns>
        public Biomorph.Common.Biomorph Map(Biomorph_Web.Models.BiomorphViewModel viewModel)
        {
            return new Biomorph.Common.Biomorph(viewModel.Alive, viewModel.MinTemp, viewModel.MaxTemp, 
                viewModel.Strength, viewModel.Intel, viewModel.Camo, viewModel.Vision, viewModel.CombatScore);
        }

        /// <summary>
        /// Maps a Biomorph Model to a BiomorphViewModel
        /// </summary>
        /// <param name="model">Model to be Mapped</param>
        /// <returns>BiomorphViewModel</returns>
        public Models.BiomorphViewModel Map(Biomorph.Common.Biomorph model)
        {
            var viewModel = new Models.BiomorphViewModel();
            viewModel.Alive = model.Alive;
            viewModel.MinTemp = model.MinTemp;
            viewModel.MaxTemp = model.MaxTemp;
            viewModel.Strength = model.Strength;
            viewModel.Intel = model.Intel;
            viewModel.Camo = model.Camo;
            viewModel.Vision = model.Vision;
            viewModel.CombatScore = model.CombatScore;

            return viewModel;
        }
    }
}