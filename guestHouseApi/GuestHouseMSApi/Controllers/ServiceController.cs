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
        public IActionResult getParentService(int branchID,int serviceTypeID)
        {
            try
            {
                if(branchID ==0 && serviceTypeID == 0)
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
                            where s.isDeleted = 0 and sc.isDeleted = 0 and branch_id = "+branchID+" and serviceTypeID = "+serviceTypeID+"";  
                }
                var appMenu = dapperQuery.Qry<ParentService>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getFoodProduct")]
        public IActionResult getFoodProduct(int branchID)
        {
            try
            {
                if(branchID ==0)
                {
                    cmd = @"select s.serviceID,serviceTypeTitle as serviceTitle,
	                        (select sub_s.serviceID,sub_s.serviceTypeTitle as serviceTitle,sub_s.serviceImagePath,sub_s.serviceImageExt, cast(sub_sc.serviceCharges as int) as serviceCharges, 0 as quantity
                            from tbl_services as sub_s inner join
                                tbl_service_charges as sub_sc on sub_s.serviceID =  sub_sc.serviceID
                            where sub_s.isDeleted = 0 and sub_sc.isDeleted = 0 and sub_s.serviceParentID =s.serviceID for json path) as subServices
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and serviceTypeID = 1 and serviceParentID is null";    
                }
                else
                {
                     cmd = @"select s.serviceID,serviceTypeTitle as serviceTitle,
	                        (select sub_s.serviceID,sub_s.serviceTypeTitle as serviceTitle,sub_s.serviceImagePath,sub_s.serviceImageExt, cast(sub_sc.serviceCharges as int) as serviceCharges, 0 as quantity
                            from tbl_services as sub_s inner join
                                tbl_service_charges as sub_sc on sub_s.serviceID =  sub_sc.serviceID
                            where sub_s.isDeleted = 0 and sub_sc.isDeleted = 0 and sub_s.serviceParentID =s.serviceID for json path) as subServices
                            from tbl_services as s inner join
                                tbl_service_charges as sc on s.serviceID =  sc.serviceID
                            where s.isDeleted = 0 and sc.isDeleted = 0 and serviceTypeID = 1 and serviceParentID is null and branch_id = "+branchID+"";  
                }
                var appMenu = dapperQuery.Qry<FoodProduct>(cmd, _dbCon);
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

        [HttpGet("getServices")]
        public IActionResult getServices(int branchID)
        {
            try
            {
              
                    cmd = @"select s.serviceTypeID,st.serviceTypeTitle,s.serviceID,s.serviceTypeTitle as serviceTitle,serviceParentID
                    ,(select serviceCharges from tbl_service_charges where isDeleted = 0 and serviceID = s.serviceID) as amount
                            ,(select serviceTypeTitle as serviceParentTitle from tbl_services where serviceID = s.serviceParentID) as serviceParentTitle,mu.measurementUnitID,mu.measurementUnitTitle
                            from tbl_service_type as st inner join 
                                tbl_services as s on st.serviceTypeID = s.serviceTypeID inner join
								tbl_service_charges as sc on s.serviceID = sc.serviceID inner join
								tbl_measurement_unit as mu on sc.measurementUnitID = mu.measurementUnitID
                            where st.isDeleted = 0 and s.isDeleted = 0 and branch_id = "+branchID+"";

                var appMenu = dapperQuery.Qry<ServicesDetail>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getFoodServices")]
        public IActionResult getFoodServices(int roomBookingID)
        {
            try
            {
              
                    cmd = @"select s.serviceTypeID,rs.serviceDate,st.serviceTypeTitle,rs.serviceQuantity,s.serviceID,s.serviceTypeTitle as serviceTitle,serviceParentID
                    ,(select serviceCharges from tbl_service_charges where isDeleted = 0 and serviceID = s.serviceID) as amount
                            ,(select serviceTypeTitle as serviceParentTitle from tbl_services where serviceID = s.serviceParentID) as serviceParentTitle
                            from tbl_service_type as st inner join 
                                tbl_services as s on st.serviceTypeID = s.serviceTypeID inner join
								tbl_room_services as rs on s.serviceID = rs.serviceID
                            where st.isDeleted = 0 and s.isDeleted = 0 and s.serviceTypeID = 1 and rs.roomBookingID = "+roomBookingID+"";

                var appMenu = dapperQuery.Qry<ServicesDetail>(cmd, _dbCon);
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

        [HttpGet("getMeasurementUnit")]
        public IActionResult getMeasurementUnit()
        {
            try
            {
                
                cmd = "Select * from tbl_measurement_unit where isDeleted = 0";    
               
                var appMenu = dapperQuery.Qry<MeasurementUnit>(cmd, _dbCon);
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

        [HttpPost("saveFoodRoomServices")]
        public ActionResult saveFoodRoomServices(FoodRoomServicesCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_roomFoodServices",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        } 

    }
}