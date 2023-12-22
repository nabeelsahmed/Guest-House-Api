using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GuestHouseMSApi.Services;
using Microsoft.Extensions.Options;
using GuestHouseMSApi.Configuration;
using GuestHouseMSApi.Entities;
using Dapper;
using System.Data;
using Newtonsoft.Json;

namespace GuestHouseMSApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FloorRoomController : ControllerBase
    {
        private readonly IOptions<conStr> _dbCon;
        private string cmd;

        public FloorRoomController(IOptions<conStr> dbCon)
        {
            _dbCon = dbCon;
        }


        [HttpGet("getRoomType")]
        public IActionResult getRoomType()
        {
            try
            {
                cmd = "select roomTypeID,roomtTypeTitle as roomTypeTitle from tbl_room_type where isDeleted = 0";    
             
                var appMenu = dapperQuery.Qry<RoomType>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getRoomAvailability")]
        public IActionResult getRoomAvailability(int branchID,int roomTypeID,int roomFeatureID)
        {

            try
            {
                if (branchID != 0 && roomTypeID != 0 && roomFeatureID != 0)
                {
                    cmd = "Select * from view_roomsAvailability Where branch_id = " + branchID + " and roomTypeID = " + roomTypeID + " and roomFeatureID = " + roomFeatureID + "";  
                }
                else if (branchID != 0 && roomTypeID != 0 && roomFeatureID == 0)
                {
                    cmd = "Select * from view_roomsAvailability where roomTypeID = " + roomTypeID + " and branch_id = " + branchID + "";
                }
                else if (branchID != 0 && roomTypeID == 0 && roomFeatureID == 0)
                {
                    cmd = "Select * from view_roomsAvailability where branch_id = " + branchID + "";
                }
                else if (branchID != 0 && roomTypeID == 0 && roomFeatureID != 0)
                {
                    cmd = "Select * from view_roomsAvailability where roomFeatureID = " + roomFeatureID + " and branch_id = " + branchID + "";
                }
                else
                {
                  cmd = "Select * from view_roomsAvailability";    
                }
                
                var appMenu = dapperQuery.Qry<RoomAvailability>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
            // try
            // {
            //     if (branchID == 0)
            //     {
            //         cmd = "select * from view_roomsAvailability";    
            //     }
            //     else
            //     {
            //         cmd = "select * from view_roomsAvailability where branch_id = " + branchID + "";
            //     }
            //     var appMenu = dapperQuery.Qry<RoomAvailability>(cmd, _dbCon);
            //     return Ok(appMenu);
            // }
            // catch (Exception e)
            // {
            //     return Ok(e);
            // }
        }


        [HttpGet("getAllFloor")]
        public IActionResult getAllFloor()
        {
            try
            {
                cmd = "Select floorID,floorNo from tbl_floor where isDeleted = 0";    
                var appMenu = dapperQuery.Qry<Floors>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getFloorRoomsName")]
        public IActionResult getFloorRoomsName(int branchID, int floorID)
        {
            try
            {
                if (branchID == 0 && floorID == 0)
                {
                    cmd = "select floorRoomID,floorRoomNo from tbl_floor_room where isDeleted = 0";    
                }
                else
                {
                    cmd = "select floorRoomID,floorRoomNo from tbl_floor_room where isDeleted = 0 and branch_id = " + branchID + " and floorID = " + floorID + "";
                }
                var appMenu = dapperQuery.Qry<FloorRoomsName>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getFloorRooms")]
        public IActionResult getFloorRooms(int branchID, int floorID)
        {
            try
            {
                
                    cmd = "select * from view_floorRoom where branch_id = " + branchID + " and floorID = " + floorID + "";
                
                var appMenu = dapperQuery.Qry<FloorRooms>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
        
        [HttpPost("saveFloorRoom")]
        public IActionResult saveFloorRoom(FloorRoomCreation model)
        {
            try
            {
                var response = dapperQuery.SPReturn("dbo.sp_floorRoomCrud",model,_dbCon);

                return Ok(response);
            }
            catch(Exception e)
            {
                return Ok(e);
            }
        }
       
        [HttpPost("saveRoomTypes")]
        public ActionResult saveRoomTypes(RoomTypesCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_roomType",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        } 
 

        
    }
}