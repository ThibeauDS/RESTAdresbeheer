using Domeinlaag.Model;
using Domeinlaag.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTlaag.Mappers;
using RESTlaag.Model.Input;
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
        private readonly GemeenteService _gemeenteService;
        private readonly StraatService _straatService;
        private readonly AdresService _adresService;
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

        [HttpPost]
        public ActionResult<GemeenteRESTOutputDTO> PostGemeente([FromBody] GemeenteRESTInputDTO restDTO)
        {
            try
            {
                Gemeente gemeente = _gemeenteService.VoegGemeenteToe(MapToDomain.MapToGemeenteDomain(restDTO));
                return CreatedAtAction(nameof(GetGemeente), new { id = gemeente.NIScode }, MapFromDomain.MapFromGemeenteDomain(url, gemeente, _straatService));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGemeente(int id)
        {
            try
            {
                _gemeenteService.VerwijderGemeente(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutGemeente(int id, [FromBody] GemeenteRESTInputDTO restDTO)
        {
            try
            {
                Gemeente gemeente = MapToDomain.MapToGemeenteDomain(restDTO);
                if (gemeente == null || gemeente.NIScode != id)
                {
                    return BadRequest();
                }
                _gemeenteService.UpdateGemeente(id, gemeente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Straat
        [HttpGet]
        [Route("{gemeenteId}/straat/{straatId}")]
        public ActionResult<StraatRESTOutputDTO> GetStraat(int gemeenteId, int straatId)
        {
            try
            {
                Straat straat = _straatService.GeefStraat(straatId);
                if (straat.Gemeente.NIScode != gemeenteId)
                {
                    return BadRequest("Gemeentecode klopt niet met url");
                }
                return Ok(MapFromDomain.MapFromStraatDomain(url, straat, _adresService));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Adres

        #endregion 
        #endregion
    }
}
