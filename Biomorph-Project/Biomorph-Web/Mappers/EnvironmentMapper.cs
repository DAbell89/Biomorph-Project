using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biomorph_Web.Mappers
{
    public class EnvironmentMapper
    {
        /// <summary>
        /// Maps ViewModel to Model
        /// </summary>
        /// <param name="viewModel">ViewModel</param>
        /// <returns>Model</returns>
        public Biomorph.Common.Environment Map(Models.EnvironmentViewModel viewModel)
        {
            return new Biomorph.Common.Environment(viewModel.Temp);
        }

        /// <summary>
        /// Maps Model to ViewModel
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns>ViewModel</returns>
        public Models.EnvironmentViewModel Map(Biomorph.Common.Environment model)
        {
            var viewModel = new Models.EnvironmentViewModel();
            viewModel.Temp = model.Temp;

            return viewModel;
        }
    }
}