using System.Collections.Generic;

namespace RESTlaag.Model.Output
{
    public class GemeenteRESTOutputDTO
    {
        #region Properties
        public string Id { get; set; }
        public int NIScode { get; set; }
        public string Naam { get; set; }
        public int AantalStraten { get; set; }
        public List<string> Straten { get; set; }
        #endregion

        #region Constructors
        public GemeenteRESTOutputDTO(string id, int nIScode, string naam, int aantalStraten, List<string> straten)
        {
            Id = id;
            NIScode = nIScode;
            Naam = naam;
            AantalStraten = aantalStraten;
            Straten = straten;
        }
        #endregion
    }
}
