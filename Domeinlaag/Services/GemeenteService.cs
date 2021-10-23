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
    public class GemeenteService
    {
        #region Properties
        private IGemeenteRepository _repo;

        #endregion

        #region Constructors
        public GemeenteService(IGemeenteRepository repo)
        {
            _repo = repo;
        }
        #endregion

        #region Methods
        public Gemeente GeefGemeente(int id)
        {
            try
            {
                return _repo.GeefGemeente(id);
            }
            catch (Exception ex)
            {
                throw new GemeenteServiceException("Geefgemeente", ex);
            }
        }
        #endregion
    }
}
