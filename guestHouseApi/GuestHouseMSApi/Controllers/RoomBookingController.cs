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

        [HttpGet("getGuestBookedRecord")]
        public IActionResult getGuestBookedRecord(int branchID)
        {
            try
            {
                cmd = @"SELECT distinct rbd.roomBookingID,p.partyID, p.partyFirstName, transactionType,p.partyLastName, p.partyCNIC, p.partyMobile, rbd.checkIn, rbd.checkOut, rbd.checkInTime, rbd.checkOutTime, rbd.reservationStatus, fr.branch_id
                        FROM   tbl_party AS p INNER JOIN
                                    tbl_room_booking AS rb ON p.partyID = rb.partyID INNER JOIN
									tbl_room_bookingDetail as rbd on rb.roomBookingID = rb.roomBookingID inner join
                                    tbl_floor_room AS fr ON rbd.floorRoomID = fr.floorRoomID INNER JOIN
                                    tbl_room_type AS rt ON fr.roomTypeID = rt.roomTypeID
                        WHERE p.isDeleted = 0 AND rb.isDeleted = 0 AND fr.isDeleted = 0 and reservationStatus ='booked' and fr.branch_id = "+branchID+"";    
                var appMenu = dapperQuery.Qry<GuestBookedRecord>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }


        [HttpGet("getGuestBookedRooms")]
        public IActionResult getGuestBookedRooms(int roomBookingID,int partyID,string checkIn,string checkOut,int branchID, int roomTypeID,string reservationStatus)
        {
            try
            {
                cmd = @"select * from fun_guestBookedRoom("+roomBookingID+","+partyID+",'"+checkIn+"','"+checkOut+"',"+branchID+", "+roomTypeID+", '"+reservationStatus+"')";    
                var appMenu = dapperQuery.Qry<GuestBookedRooms>(cmd, _dbCon);
                return Ok(appMenu);
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

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

        [HttpGet("getRoomReservationCurrent")]
        public IActionResult getRoomReservationCurrent(int branchID)
        {
            try
            {
                cmd = @"SELECT distinct p.partyID, p.partyFirstName, p.partyLastName, p.partyCNIC, p.partyMobile, rb.checkIn, rb.checkOut, rb.checkInTime, rb.checkOutTime,branch_id
                        FROM   dbo.tbl_party AS p INNER JOIN
                                    dbo.tbl_room_booking AS rb ON p.partyID = rb.partyID inner join
                                    tbl_floor_room as fr on rb.floorRoomID = fr.floorRoomID
                        WHERE (p.isDeleted = 0) AND (rb.isDeleted = 0) and reservationStatus = 'reserved' and getdate() < checkOut and branch_id = "+branchID+""; 

                var appMenu = dapperQuery.Qry<RoomReservationCurrent>(cmd, _dbCon);
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