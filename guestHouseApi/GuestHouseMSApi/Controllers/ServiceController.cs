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
                    cmd = @"select s.serviceID as parentServiceID,serviceTypeTitle as serviceTitle,serviceImagePath,serviceImageExt,sc.serviceCharges 
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0";    
                }
                else
                {
                     cmd = @"select s.serviceID as parentServiceID,serviceTypeTitle as serviceTitle,serviceImagePath,serviceImageExt,sc.serviceCharges 
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and branch_id = "+branchID+"";  
                }
                var appMenu = dapperQuery.Qry<ParentService>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }


        [HttpGet("getCatgoryProduct")]
        public IActionResult getCatgoryProduct(int branchID)
        {
            try
            {
                if(branchID ==0)
                {
                    cmd = @"select s.serviceID as parentServiceID,serviceTypeTitle as serviceTitle,serviceImagePath,serviceImageExt,sc.serviceCharges 
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and serviceParentID is null";    
                }
                else
                {
                     cmd = @"select s.serviceID as parentServiceID,serviceTypeTitle as serviceTitle,serviceImagePath,serviceImageExt,sc.serviceCharges 
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and serviceParentID is null and branch_id = "+branchID+"";  
                }
                var appMenu = dapperQuery.Qry<ParentService>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getSubCatgoryProduct")]
        public IActionResult getSubCatgoryProduct(int branchID,int serviceID)
        {
            try
            {
                if(branchID ==0)
                {
                    cmd = @"select s.serviceID as parentServiceID,serviceTypeTitle as serviceTitle,serviceImagePath,serviceImageExt,sc.serviceCharges 
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and serviceParentID = "+serviceID+"";    
                }
                else
                {
                     cmd = @"select s.serviceID as parentServiceID,serviceTypeTitle as serviceTitle,serviceImagePath,serviceImageExt,sc.serviceCharges 
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and serviceParentID = "+serviceID+" and branch_id = "+branchID+"";  
                }
                var appMenu = dapperQuery.Qry<ParentService>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getRoomServices")]
        public IActionResult getRoomServices(int roomBookingID)
        {
            try
            {
                
                cmd = "Select * from view_roomServices where roomBookingID = "+roomBookingID+"";    
               
                var appMenu = dapperQuery.Qry<RoomServices>(cmd, _dbCon);
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

        [HttpPost("saveRoomServices")]
        public ActionResult saveRoomServices(RoomServicesCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_roomServices",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        } 

    }
}