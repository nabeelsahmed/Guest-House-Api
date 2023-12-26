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

        // [HttpGet("getAvailableRooms")]
        // public IActionResult getAvailableRooms(int roomTypeID,int subFeatureID,int roomFeatureID)
        // {
        //     try
        //     {
        //         if (subFeatureID == 0 && roomFeatureID == 0)
        //         {
        //             cmd = "Select * from view_availableRooms where roomTypeID = " + roomTypeID + " ";    
        //         }
        //         else if (subFeatureID == 0)
        //         {
        //             cmd = "Select * from view_availableRooms where roomTypeID = " + roomTypeID + " and subFeatureID = " + subFeatureID + "";
        //         }
        //         else if (roomTypeID != 0 && subFeatureID != 0 && roomFeatureID != 0)
        //         {
        //             cmd = "Select * from view_availableRooms where roomTypeID = " + roomTypeID + " and subFeatureID = " + subFeatureID + " and roomFeatureID = " + roomFeatureID + "";
        //         }
        //         else if (subFeatureID == 0)
        //         {
        //             cmd = "Select * from view_availableRooms where roomTypeID = " + roomTypeID + " and roomFeatureID = " + roomFeatureID + "";
        //         }
        //         else if (subFeatureID != 0 && roomFeatureID == 0 && roomTypeID == 0)
        //         {
        //             cmd = "Select * from view_availableRooms Where subFeatureID = " + subFeatureID + "";
        //         }
        //         else if (subFeatureID != 0 && roomFeatureID != 0 && roomTypeID == 0)
        //         {
        //             cmd = "Select * from view_availableRooms Where subFeatureID = " + subFeatureID + " and roomFeatureID = " + roomFeatureID + "";
        //         }
        //         else if (subFeatureID == 0 && roomFeatureID != 0 && roomTypeID == 0)
        //         {
        //             cmd = "Select * from view_availableRooms Where roomFeatureID = " + roomFeatureID + "";
        //         }
                
        //         var appMenu = dapperQuery.Qry<RoomType>(cmd, _dbCon);
        //         return Ok(appMenu);
        //     }
        //     catch (Exception e)
        //     {
        //         return Ok(e);
        //     }
        // }

        // [HttpGet("getServices")]
        // public IActionResult getServices()
        // {
        //     try
        //     {
        //         cmd = "Select * from tbl_guest_house_service Where isDeleted = 0 and (serviceParentID IS NULL OR serviceParentID = 0)";    
        //         var appMenu = dapperQuery.Qry<GuestHouseServices>(cmd, _dbCon);
        //         return Ok(appMenu);
        //     }
        //     catch (Exception e)
        //     {
        //         return Ok(e);
        //     }
        // }

        [HttpGet("getRoomBooking")]
        public IActionResult getRoomBooking(int branchID)
        {
            try
            {
                cmd = "select * from view_roomBooking where reservationStatus = 'booked' and branch_id = "+branchID+"";    
                var appMenu = dapperQuery.Qry<RoomBooking>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpGet("getRoomReservation")]
        public IActionResult getRoomReservation()
        {
            try
            {
                cmd = "select * from view_roomReservation";    
                var appMenu = dapperQuery.Qry<RoomReservation>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpPost("saveRoomBooking")]
        public IActionResult saveRoomBooking(RoomBookingCreation model)
        {
            try
            {
                var response = dapperQuery.SPReturn("sp_roomBooking", model, _dbCon);
                return Ok(response);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
        
    }
}