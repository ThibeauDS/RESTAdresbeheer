using Domeinlaag.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Model
{
    public class Adres
    {
        #region Properties
        public int ID { get; private set; }
        public Straat Straat { get; private set; }
        public string Huisnummer { get; private set; }
        public string Appartementnummer { get; private set; }
        public string Busnummer { get; private set; }
        public int Postcode { get; private set; }
        public AdresLocatie Locatie { get; private set; }
        #endregion

        #region Constructors
        public Adres(int iD, Straat straat, string huisnummer, string appartementnummer, string busnummer, int postcode, AdresLocatie locatie)
        {
            ZetId(ID);
            ZetStraat(straat);
            ZetHuisnummer(huisnummer);
            ZetAppartementnummer(appartementnummer);
            ZetBusnummer(busnummer);
            ZetPostcode(postcode);
            ZetLocatie(locatie);
        }
        public Adres(Straat straat, string huisnummer, string appartementnummer, string busnummer, int postcode, AdresLocatie locatie)
        {
            ZetStraat(straat);
            ZetHuisnummer(huisnummer);
            ZetAppartementnummer(appartementnummer);
            ZetBusnummer(busnummer);
            ZetPostcode(postcode);
            ZetLocatie(locatie);
        }
        #endregion

        #region Methods
        public void ZetId(int id)
        {
            if (id < 0)
            {
                throw new AdresException("Adres id fout");
            }
            ID = id;
        }

        public void ZetStraat(Straat straat)
        {
            if (straat == null) throw new AdresException("Straat is null");
            Straat = straat;
        }

        public void ZetHuisnummer(string huisnummer)
        {
            if (string.IsNullOrWhiteSpace(huisnummer)) throw new AdresException("Huisnummer is leeg");
            Huisnummer = huisnummer;
        }

        public void ZetAppartementnummer(string appartementnummer)
        {
            if (string.IsNullOrWhiteSpace(appartementnummer)) throw new AdresException("appartementnummer is leeg");
            Appartementnummer = appartementnummer;
        }

        public void ZetBusnummer(string busnummer)
        {
            if (string.IsNullOrWhiteSpace(busnummer)) throw new AdresException("busnummer is leeg");
            Busnummer = busnummer;
        }

        public void ZetPostcode(int postcode)
        {
            if (postcode < 1000 || postcode > 9999)
            {
                throw new AdresException("postcode is niet correct");
            }
            Postcode = postcode;
        }

        public void ZetLocatie(AdresLocatie locatie)
        {
            if (locatie == null) throw new AdresException("locatie is null");
            Locatie = locatie;
        }
        #endregion
    }
}
