﻿using Domeinlaag.Exceptions;
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
                throw new GemeenteServiceException("GeefGemeente", ex);
            }
        }

        public Gemeente VoegGemeenteToe(Gemeente gemeente)
        {
            try
            {
                if (gemeente == null) throw new GemeenteServiceException("VoegGemeenteToe - gemeente is null");
                if (_repo.HeeftGemeente(gemeente.NIScode)) throw new GemeenteServiceException("VoegGemeenteToe - gemeente bestaat al");
                _repo.VoegGemeenteToe(gemeente);
                return gemeente;
            }
            catch (Exception ex)
            {
                throw new GemeenteServiceException("VoegGemeenteToe", ex);
            }
        }
        #endregion
    }
}
