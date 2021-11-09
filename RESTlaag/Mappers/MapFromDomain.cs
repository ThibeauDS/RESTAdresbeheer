using Domeinlaag.Model;
using Domeinlaag.Services;
using RESTlaag.Exceptions;
using RESTlaag.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RESTlaag.Mappers
{
    public static class MapFromDomain
    {
        #region Methods
        public static GemeenteRESTOutputDTO MapFromGemeenteDomain(string url, Gemeente gemeente, StraatService straatService)
        {
            try
            {
                string gemeenteURL = $"{url}/gemeente/{gemeente.NIScode}";
                List<string> straten = straatService.GeefStratenGemeente(gemeente.NIScode).Select(x => gemeenteURL + $"/straat/{x.ID}").ToList();
                GemeenteRESTOutputDTO dto = new(gemeenteURL, gemeente.NIScode, gemeente.Gemeentenaam, straten.Count, straten);
                return dto;
            }
            catch (Exception ex)
            {
                throw new MapException("MapFromGemeenteDomain", ex);
            }
        }
        #endregion
    }
}
