using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Storage.Service.Interfaces;

namespace Storage.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService storageService;

        /// <summary>
        /// StorageController Constructor Definition
        /// </summary>
        /// <param name="storageService"></param>
        public StorageController(IStorageService storageService)
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
