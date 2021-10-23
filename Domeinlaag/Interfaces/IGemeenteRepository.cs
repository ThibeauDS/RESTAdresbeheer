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
    }
}
