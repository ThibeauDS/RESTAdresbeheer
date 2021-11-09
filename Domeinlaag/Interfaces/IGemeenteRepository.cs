using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domeinlaag.Interfaces
{
    public interface IGemeenteRepository
    {
        Gemeente GeefGemeente(int id);
        bool HeeftGemeente(int nIScode);
        void VoegGemeenteToe(Gemeente gemeente);
        void VerwijderGemeente(int id);
        void UpdateGemeente(Gemeente gemeente);
        bool HeeftStraten(int id);
    }
}
