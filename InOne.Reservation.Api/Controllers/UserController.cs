using System.Web.Http;

namespace InOne.Reservation.Api.Controllers
{
    public class UserController : BaseController
    {

        [BasicAuthentication]
        [HttpGet, Route("api/users")]
        public IHttpActionResult GetUsers() => Json(UnitOfWork.UserManager.GetDtos());
        [BasicAuthentication, HttpGet, Route("user")]
        public IHttpActionResult GetUser(int Id) => Json(UnitOfWork.UserManager.GetDto(Id));
        [BasicAuthentication, HttpDelete, Route("delete")]
        public IHttpActionResult DeleteUser(int Id)
        {
            UnitOfWork.UserManager.DeleteById(Id);
            UnitOfWork.Commit();
            return Json("Success");
        }
    }
}
