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
    public class AdresService
    {
        #region Properties
        private IAdresRepository _repo;
        #endregion

        #region Constructors
        public AdresService(IAdresRepository repo)
        {
            _repo = repo;
        }
        #endregion

        public IEnumerable<Adres> GeefAdressenStraat(int id)
        {
            try
            {
                return _repo.GeefAdressenStraat(id);
            }
            catch (Exception ex)
            {
                throw new AdresServiceException("GeefAdressenStraat", ex);
            }
        }
    }
}
