using Domeinlaag.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Model
{
    public class AdresLocatie
    {
        #region Properties
        public double X { get; private set; }
        public double Y { get; private set; }
        #endregion

        #region Constructors
        public AdresLocatie(double x, double y)
        {
            ZetX(x);
            ZetY(y);
        }
        #endregion

        #region Methods
        public void ZetX(double x)
        {
            if ((x < 22000) || (x > 258000))
            {
                AdresLocatieException ex = new("x coördinaat niet correct");
                ex.Data.Add("x", x);
                throw ex;
            }
            X = x;
        }

        public void ZetY(double y)
        {
            if ((y < 152000) || (y > 244000))
            {
                AdresLocatieException ex = new("y coördinaat niet correct");
                ex.Data.Add("y", y);
                throw ex;
            }
            Y= y;
        }
        #endregion
    }
}
