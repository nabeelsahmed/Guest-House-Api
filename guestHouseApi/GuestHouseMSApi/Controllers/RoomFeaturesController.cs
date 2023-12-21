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
    public class RoomFeaturesController : ControllerBase
    {
      private readonly IOptions<conStr> _dbCon;
        private string cmd;

        public RoomFeaturesController(IOptions<conStr> dbCon)
        {
            _dbCon = dbCon;
        }

        [HttpGet("getRoomFeatures")]
        public IActionResult getRoomFeatures()
        {
            try
            {
                cmd = "select * from tbl_room_features";    
                var appMenu = dapperQuery.Qry<roomFeatures>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getParentRoomFeatures")]
        public IActionResult getParentRoomFeatures()
        {
            try
            {
                cmd = "select * from tbl_room_features where isDeleted = 0 and roomFeatureParentID is null";    
                var appMenu = dapperQuery.Qry<roomFeatures>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getFloorRoomFeatures")]
        public IActionResult getFloorRoomFeatures()
        {
            try
            {
                cmd = "select * from view_roomFeatures";    
                var appMenu = dapperQuery.Qry<roomFeatures>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpPost("saveRoomFeatures")]
        public ActionResult saveRoomFeatures(RoomFeaturesCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_roomFeatures",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        }       

         [HttpPost("saveFloorRoomFeatures")]
        public ActionResult saveFloorRoomFeatures(FloorRoomFeatureCreation model)
        {
            try
            {
                var row = dapperQuery.SPReturn("sp_floorRoomFeatures",model,_dbCon);
                return Ok(row);
            }
            catch(Exception e )
            {
                return Ok(e);
            }
        }       

              
    }
}