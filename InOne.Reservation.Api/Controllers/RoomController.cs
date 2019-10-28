using InOne.Reservation.Manager.IMPL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InOne.Reservation.Api.Controllers
{
    public class RoomController : BaseController
    {
        [BasicAuthentication]
        [HttpGet, Route("api/rooms")]
        public IHttpActionResult GetRooms() => Json(UnitOfWork.RoomManager.GetDtos());
        [BasicAuthentication, HttpGet, Route("room")]
        public IHttpActionResult GetRoom(int Id) => Json(UnitOfWork.RoomManager.GetDto(Id));
        [BasicAuthentication, HttpDelete, Route("delete")]
        public IHttpActionResult DeleteRoom(int Id)
        {
            UnitOfWork.RoomManager.DeleteById(Id);
            UnitOfWork.Commit();
            return Json("Success");
        }

    }
}
