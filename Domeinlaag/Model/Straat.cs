using Domeinlaag.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Model
{
    public class Straat
    {
        #region Properties
        public int ID { get; private set; }
        public string Straatnaam { get; private set; }
        public Gemeente Gemeente { get; private set; }
        #endregion

        #region Constructors
        public Straat(int ID, string straatnaam, Gemeente gemeente)
        {
            ZetID(ID);
            ZetStraatnaam(straatnaam);
            ZetGemeente(gemeente);
        }

        public Straat(string straatnaam, Gemeente gemeente)
        {
            ZetStraatnaam(straatnaam);
            ZetGemeente(gemeente);
        }
        public Straat(string straatnaam)
        {
            ZetStraatnaam(straatnaam);
        }
        #endregion

        #region Methods
        public void ZetStraatnaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam))
            {
                StraatException ex = new StraatException("Naam niet correct.");
                ex.Data.Add("Straatnaam", naam);
                throw ex;
            }
            Straatnaam = naam;
        }

        public void ZetID(int id)
        {
            if (id <= 0)
            {
                StraatException ex = new StraatException("ID niet correct.");
                ex.Data.Add("ID", id);
                throw ex;
            }
            ID = id;
        }

        public void ZetGemeente(Gemeente gemeente)
        {
            if (gemeente == null)
            {
                throw new StraatException("ZetGemeente - null");
            }
            if (gemeente == Gemeente)
            {
                throw new StraatException("ZetGemeente - niet nieuw");
            }
            Gemeente = gemeente;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
