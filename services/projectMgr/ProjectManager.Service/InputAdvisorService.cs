using Microsoft.Extensions.Options;
using ProjectManager.Constants.InputAdvisor;
using ProjectManager.DataAccess;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using ProjectManager.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace ProjectManager.Service
{
    public class InputAdvisorService : IInputAdvisorService
    {

        private readonly IInputAdvisorDataAccess inputAdvisorDataAccess;
        public InputAdvisorService(IOptions<ProjectManagerSettings> settings)
        {
            inputAdvisorDataAccess = new InputAdvisorDataAccess(settings.Value.ConnectionString);
        }

        /// <summary>
        ///Geographies service method for listing all available geographies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Geography> GetGeographies()
        {
            try
            {
                return inputAdvisorDataAccess.GetGeographies();
            }
            catch (Exception getGeographiesException)
            {
                throw new Exception(GeographyExceptionMessages.GET_GEOGRAPHIES_SERVICE_ERROR_MSG, getGeographiesException);
            }
        }
    }
}