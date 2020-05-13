using ProjectManager.Constants.InputAdvisor;
using ProjectManager.DataAccess.Factory;
using ProjectManager.DataAccess.Interfaces;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjectManager.DataAccess
{
    public class InputAdvisorDataAccess : IInputAdvisorDataAccess
    {
        private readonly IProjectDBManager projectDBManager;
        public InputAdvisorDataAccess(string connectionString)
        {
            projectDBManager = new ProjectDBManager(connectionString);
        }

        public IEnumerable<Geography> GetGeographies()
        {
            try
            {
                DataTable dtGeography = projectDBManager.GetDataTable("SELECT id,value FROM project.get_geography_list()", CommandType.Text);
                List<Geography> geographies = dtGeography.AsEnumerable()
                                      .Select(x => new Geography()
                                      {
                                          ID = x.Field<Int16>("id"),
                                          Value = x.Field<string>("value")
                                      }).ToList();
                return geographies;
            }
            catch (Exception getGeographiesException)
            {
                throw new Exception(GeographyExceptionMessages.GET_GEOGRAPHIES_DATA_ACCESS_ERROR_MSG, getGeographiesException);
            }
        }
    }
}