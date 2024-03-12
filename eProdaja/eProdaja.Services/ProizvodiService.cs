using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService:IProizvodiServices
    {
        public List<Proizvodi> List = new List<Proizvodi>()
        {
            new Proizvodi()
            {
                ProizvodID = 1,
                Naziv = "Laptop",
                Cijena = 999
            },
            new Proizvodi()
            {
                ProizvodID = 2,
                Naziv = "Monitor",
                Cijena = 613
            }
        };

        public virtual List<Proizvodi> GetList()
        {
            return List;
        }
    }
}
