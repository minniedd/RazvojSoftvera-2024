using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public interface IVrsteProizvodaService
    {
        List<VrsteProizvoda> GetList(VrsteProizvodaSearchObject searchObject);
    }
}
