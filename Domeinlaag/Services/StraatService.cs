using Domeinlaag.Exceptions;
using Domeinlaag.Interfaces;
using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Services
{
    public class StraatService
    {
        #region Properties
        private IStraatRepository _repo;
        #endregion

        #region Methods
        public List<Straat> GeefStratenGemeente(int nIScode)
        {
            try
            {
                return _repo.GeefStratenGemeente(nIScode);
            }
            catch (Exception ex)
            {
                throw new StraatServiceException("GeefStratenGemeente", ex);
            }
        }
        #endregion
    }
}
