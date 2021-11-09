using System.Collections.Generic;

namespace RESTlaag.Model.Output
{
    public class StraatRESTOutputDTO
    {
        #region Properties
        public string Id { get; set; }
        public string Straatnaam { get; set; }
        public string Gemeente { get; set; }
        public int AantalAdressen { get; set; }
        public List<string> Adressen { get; set; }
        #endregion

        #region Constructors
        public StraatRESTOutputDTO(string id, string straatnaam, string gemeente, int aantalAdressen, List<string> adressen)
        {
            Id = id;
            Straatnaam = straatnaam;
            Gemeente = gemeente;
            AantalAdressen = aantalAdressen;
            Adressen = adressen;
        }
        #endregion
    }
}
