using System.Web.Http;

namespace InOne.Reservation.Api.Controllers
{
    public class BookingController : BaseController
    {
        [BasicAuthentication]
        [HttpGet, Route("api/bookings")]
        public IHttpActionResult GetBookings() => Json(UnitOfWork.BookingManager.GetDtos());
        [BasicAuthentication, HttpGet, Route("api/booking")]
        public IHttpActionResult GetBooking(int Id) => Json(UnitOfWork.BookingManager.GetDto(Id));
        [BasicAuthentication, HttpDelete, Route("delete")]
        public IHttpActionResult DeleteBooking(int Id)
        {
            UnitOfWork.BookingManager.DeleteById(Id);
            UnitOfWork.Commit();
            return Json("Success");
        }
    }
}
