using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAugmentation.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAugmentation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataAugmentationController : ControllerBase
    {
        private readonly IDataAugmentationService storageService;

        /// <summary>
        /// StorageController Constructor Definition
        /// </summary>
        /// <param name="storageService"></param>
        public DataAugmentationController(IDataAugmentationService storageService)
        {
            this.storageService = storageService;
        }

        /// <summary>
        /// POST endpoint for Simulating the Solaris Design
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Storage()
        {
            //1. Saving Project Storage Data
            //2. Generating Multiple Models
            //3. Saving Multiple Models
            //4. Adding Messages to Queues
            return Ok("Success");
        }

        /// <summary>
        /// Get endpoint for getting the Models count
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> GetModelCount()
        {
            int modelCount = storageService.GetModelCount();
            return Ok(modelCount);
        }
    }
}