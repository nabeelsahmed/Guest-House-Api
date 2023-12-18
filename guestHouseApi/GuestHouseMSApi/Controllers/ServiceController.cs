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

        [HttpGet("getServiceType")]
        public IActionResult getServiceType()
        {
            try
            {
                
                cmd = "Select * from tbl_service_type";    
               
                var appMenu = dapperQuery.Qry<ServiceType>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getParentService")]
        public IActionResult getParentService(int branchID)
        {
            try
            {
                if(branchID ==0)
                {
                    cmd = "select serviceID as parentServiceID,serviceTypeTitle as serviceTitle from tbl_services where isDeleted = 0";    
                }
                else
                {
                     cmd = "select serviceID as parentServiceID,serviceTypeTitle as serviceTitle from tbl_services where isDeleted = 0 and branch_id = "+branchID+"";  
                }
                var appMenu = dapperQuery.Qry<ParentService>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
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

        [HttpPost("saveServiceCharges")]
        public ActionResult saveServiceChargesDetail(ServiceChargesCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_serviceChargesDetail",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        } 

    }
}