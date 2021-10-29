using Domeinlaag.Model;
using RESTlaag.Exceptions;
using RESTlaag.Model.Input;
using System;

namespace RESTlaag.Mappers
{
    public static class MapToDomain
    {
        #region Methods
        public static Gemeente MapToGemeenteDomain(GemeenteRESTInputDTO dto)
        {
            try
            {
                Gemeente gemeente = new(dto.NIScode, dto.Naam);
                return gemeente;
            }
            catch (Exception ex)
            {
                throw new MapException("MapToGemeenteDomain: ", ex);
            }
        }
        #endregion
    }
}
