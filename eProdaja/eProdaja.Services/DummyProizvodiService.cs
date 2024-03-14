using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class DummyProizvodiService:IProizvodiServices
    {
        public new List<Proizvodi> List = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                ProizvodID = 1,
                Naziv = "Laptop",
                Cijena = 999
            }
        };

        public List<Proizvodi> GetList(ProizvodiSearchObject searchObject)
        {
            return List;
        }
    }
}
