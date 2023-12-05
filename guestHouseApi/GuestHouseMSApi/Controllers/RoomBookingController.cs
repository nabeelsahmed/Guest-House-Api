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
    public class RoomBookingController : ControllerBase
    {
        private readonly IOptions<conStr> _dbCon;
        private string cmd;

        public RoomBookingController(IOptions<conStr> dbCon)
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
        
    }
}