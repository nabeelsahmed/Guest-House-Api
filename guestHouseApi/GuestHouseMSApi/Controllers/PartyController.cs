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
    public class PartyController : ControllerBase
    {
        private readonly IOptions<conStr> _dbCon;
        private string cmd;

        public PartyController(IOptions<conStr> dbCon)
        {
            _dbCon = dbCon;
        }

        [HttpGet("getParty")]
        public IActionResult getParty(int partyID)
        {
            try
            {
                if (partyID == 0)
                {
                    cmd = "Select * from tbl_party where isDeleted = 0";    
                }
                else
                {
                    cmd = "Select * from tbl_party where isDeleted = 0 and partyID = " + partyID + "";   
                }
                var appMenu = dapperQuery.Qry<Party>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getPartyStatus")]
        public IActionResult getPartyStatus()
        {
            try
            {
                
                cmd = "Select * from view_guestStatus";    
               
                var appMenu = dapperQuery.Qry<PartyStatus>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpPost("saveParty")]
        public IActionResult saveParty(PartyCreation model)
        {
            try
            {
                var response = dapperQuery.SPReturn("sp_party", model, _dbCon);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
        
    }
}