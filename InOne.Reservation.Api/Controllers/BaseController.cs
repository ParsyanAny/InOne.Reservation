using InOne.Reservation.DataAccess;
using InOne.Reservation.Manager.IMPL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InOne.Reservation.Api.Controllers
{
    public class BaseController : ApiController
    {
        protected ApplicationContext _context = new ApplicationContext();

        protected UnitOfWork  UnitOfWork => new UnitOfWork(_context);
    }
}
