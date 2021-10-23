using Domeinlaag.Model;
using Domeinlaag.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTlaag.Mappers;
using RESTlaag.Model.Output;
using System;

namespace RESTlaag.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresBeheerController : ControllerBase
    {
        #region Properties
        private string url = "http://localhost:5000";
        private GemeenteService _gemeenteService;
        private StraatService _straatService;
        #endregion

        #region Constructors
        public AdresBeheerController(GemeenteService gemeenteService, StraatService straatService)
        {
            _gemeenteService = gemeenteService;
            _straatService = straatService;
        }
        #endregion

        #region Methods
        #region Gemeente
        [HttpGet("{id}")]
        public ActionResult<GemeenteRESTOutputDTO> GetGemeente(int id)
        {
            try
            {
                Gemeente gemeente = _gemeenteService.GeefGemeente(id);
                return Ok(MapFromDomain.MapFromGemeenteDomain(url, gemeente, _straatService));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region Straat

        #endregion

        #region Adres

        #endregion 
        #endregion
    }
}
