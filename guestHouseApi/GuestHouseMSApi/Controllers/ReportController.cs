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
    public class ReportController : ControllerBase
    {
        private readonly IOptions<conStr> _dbCon;
        private string cmd;

        public ReportController(IOptions<conStr> dbCon)
        {
            _dbCon = dbCon;
        }

        [HttpGet("getRoomBookingRecord")]
        public IActionResult getRoomBookingRecord(int roomBookingID)
        {
            try
            {
                if (roomBookingID == 0)
                {
                    cmd = "Select * from view_roomBookingRecord";    
                }
                else
                {
                    cmd = "Select * from view_roomBookingRecord where roomBookingID = " + roomBookingID + "";   
                }
                var appMenu = dapperQuery.Qry<RoomBookingRecord>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }


        [HttpGet("getGuestBookingRecord")]
        public IActionResult getGuestBookingRecord(int partyID, string checkIn, string checkOut)
        {
            try
            {
                
                cmd = "select * from view_guestBookingRecord where partyID = "+partyID+" and checkIn = '"+checkIn+"' and checkOut = '"+checkOut+"'";   
                
                var appMenu = dapperQuery.Qry<GuestBookingRecord>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        
        
    }
}