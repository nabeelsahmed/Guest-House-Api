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
        public IActionResult getRoomAvailability(int branchID)
        {
            try
            {
                if (branchID == 0)
                {
                    cmd = "select * from view_roomsAvailability";    
                }
                else
                {
                    cmd = "select * from view_roomsAvailability where branch_id = " + branchID + "";
                }
                var appMenu = dapperQuery.Qry<RoomAvailability>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
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

        // [HttpGet("getFloorRooms")]
        // public IActionResult getFloorRooms(int branchID, int floorID)
        // {
        //     try
        //     {
        //         if (branchID == 0 && floorID == 0)
        //         {
        //             cmd = "select floorRoomID,floorRoomNo from tbl_floor_room where isDeleted = 0";    
        //         }
        //         else
        //         {
        //             cmd = "select floorRoomID,floorRoomNo from tbl_floor_room where isDeleted = 0 and branch_id = " + branchID + " and floorID = " + floorID + "";
        //         }
        //         var appMenu = dapperQuery.Qry<FloorRooms>(cmd, _dbCon);
        //         return Ok(appMenu);
        //     }
        //     catch (Exception e)
        //     {
        //         return Ok(e);
        //     }
        // }

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