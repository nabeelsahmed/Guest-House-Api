using System;
using GuestHouseMSApi.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using GuestHouseMSApi.Services;
using GuestHouseMSApi.Entities;


namespace GuestHouseMSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IOptions<conStr> _dbCon;
        private string cmd;
        public ServiceController(IOptions<conStr> dbCon)
        {
            _dbCon = dbCon;
        }

         [HttpPost("saveServices")]
        public ActionResult saveServices(ServiceCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_services",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        } 

    }
}