using Domeinlaag.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Model
{
    public class Gemeente
    {
        #region Properties
        public int NIScode { get; private set; }
        public string Gemeentenaam { get; private set; }
        #endregion

        #region Constructors
        public Gemeente(int nIScode, string gemeentenaam)
        {
            NIScode = nIScode;
            Gemeentenaam = gemeentenaam;
        }
        #endregion

        #region Methods
        public void ZetGemeentenaam(string naam)
        {
            if(string.IsNullOrWhiteSpace(naam) || (!char.IsUpper(naam[0])))
            {
                GemeenteException ex = new GemeenteException("Naam niet correct.");
                ex.Data.Add("Gemeentenaam", naam);
                throw ex;
            }
            Gemeentenaam = naam;
        }

        public void ZetNIScode(int code)
        {
            if (code < 10000 || code > 99999)
            {
                GemeenteException ex = new GemeenteException("NIScode niet correct.");
                ex.Data.Add("NIScode", code);
                throw ex;
            }
            NIScode = code;
        }
        #endregion
    }
}
