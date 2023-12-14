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
        public IActionResult getRoomType(int branchID)
        {
            try
            {
                if (branchID == 0)
                {
                    cmd = "Select roomTypeID,roomtTypeTitle as roomTypeTitle from tbl_room_type Where isDeleted = 0 ";    
                }
                else
                {
                    cmd = "Select roomTypeID,roomtTypeTitle as roomTypeTitle from tbl_room_type Where isDeleted = 0 and branch_id = " + branchID + "";
                }
                var appMenu = dapperQuery.Qry<RoomType>(cmd, _dbCon);
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
        [HttpGet("getroomfeature")]
        public IActionResult getroomfeature()
        {
            try
            {
                cmd = "select * from tbl_room_features";    
                var appMenu = dapperQuery.Qry<roomfeatures>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
        [HttpPost("SavefloorRoom")]
        public IActionResult SavefloorRoom(savefloorRoom model)
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
        [HttpPost("SaveRoomFeature")]
        public IActionResult SaveRoomFeature(saveRoomFeature model)
        {
            try
            {
                var response = dapperQuery.SPReturn("dbo.sp_roomFeatureCrud",model,_dbCon);

                return Ok(response);
            }
            catch(Exception e)
            {
                return Ok(e);
            }
        }
        [HttpPost("SaveFloorRoomFeature")]
        public IActionResult SaveFloorRoomFeature(savefloorRoomFeature model)
        {
            try
            {
                var response = dapperQuery.SPReturn("dbo.sp_floorRoomFeatureCrud",model,_dbCon);

                return Ok(response);
            }
            catch(Exception e)
            {
                return Ok(e);
            }
        }
        
    }
}