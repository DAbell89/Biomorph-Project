using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biomorph_Web.Mappers
{
    public class WorldMapper
    {
        public Biomorph.Common.World Map(Models.WorldViewModel viewModel)
        {
            var model = new Biomorph.Common.World();
            var bioMapper = new BiomorphMapper();
            model.Bio = bioMapper.Map(viewModel.Bio);
            model.Opponent = bioMapper.Map(viewModel.Opponent);

            if (viewModel.Offspring != null)
            {
                var offspring = new List<Biomorph.Common.Biomorph>();

                foreach (var child in viewModel.Offspring)
                {
                    offspring.Add(bioMapper.Map(child));
                }
            }

            var evoMapper = new EnvironmentMapper();
            model.Environment = evoMapper.Map(viewModel.Environment);

            return model;
        }

        public Models.WorldViewModel Map(Biomorph.Common.World model)
        {
            var viewModel = new Models.WorldViewModel();
            var bioMapper = new BiomorphMapper();
            viewModel.Bio = bioMapper.Map(model.Bio);
            viewModel.Opponent = bioMapper.Map(model.Opponent);

            if (model.Offspring != null)
            {
                var offspring = new List<Models.BiomorphViewModel>();

                foreach (var child in model.Offspring)
                {
                    offspring.Add(bioMapper.Map(child));
                }
            }

            var evoMapper = new EnvironmentMapper();
            viewModel.Environment = evoMapper.Map(model.Environment);

            return viewModel;
        }
    }
}