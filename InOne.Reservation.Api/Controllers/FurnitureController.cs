using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InOne.Reservation.Api.Controllers
{
    public class FurnitureController : BaseController
    {
        [BasicAuthentication]
        [HttpGet, Route("furnitures")]
        public IHttpActionResult GetFurnitures() => Json(UnitOfWork.FurnitureManager.GetDtos());
        [BasicAuthentication, HttpGet, Route("{FurnitureId}")]
        public IHttpActionResult GetFurniture(int Id) => Json(UnitOfWork.FurnitureManager.GetDto(Id));
        [BasicAuthentication, HttpDelete, Route("Delete/{Id}")]
        public IHttpActionResult DeleteFurniture(int Id)
        {
            UnitOfWork.FurnitureManager.DeleteById(Id);
            UnitOfWork.Commit();
            return Json("Success");
        }

        //[BasicAuthentication]
        //[HttpPost, Route("addbranch")]
        //public IHttpActionResult PostBranch([FromBody]BranchDTO branch)
        //{
        //    BranchDTOManager.AddBranch(branch);
        //    return Ok("Success");
        //}


        //[BasicAuthentication]
        //[HttpDelete, Route("deletebranch")]
        //public IHttpActionResult DeleteBranch(int branchId)
        //{
        //    BranchDTOManager.DeleteBranch(branchId);
        //    return Json("Success");
        //}
    }
}
