using Challenge1HackTeam3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{

    [EnableCors("*", "*", "*")]
    public class UBSController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetC()
        {
            return Ok(UbsAPI.GetUbs());
        }

        [HttpGet]
        public IHttpActionResult GetCidades(string cidade)
        {
            return Ok(UbsAPI.getUbsByCity(cidade));
        }

        [HttpGet]
        public IHttpActionResult getUbsProxima(double latitude, double longitude)
        {
            return Ok(UbsAPI.GetUbsByLat(latitude, longitude));
        }

    }
}
