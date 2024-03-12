using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService:IKorisniciService
    {
        public EProdajaContext Context { get; set; }
        public IMapper _mapper { get; set; }

        public KorisniciService(EProdajaContext context,IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public virtual List<Model.Korisnici> GetList()
        {
            List<Model.Korisnici> result = new List<Model.Korisnici>();

            var list = Context.Korisnicis.ToList();
            //list.ForEach(item => result.Add(new Model.Korisnici
            //{
            //    KorisnikId = item.KorisnikId,
            //    Ime = item.Ime,
            //    Prezime = item.Prezime,
            //    Email = item.Email,
            //    KorisnickoIme = item.KorisnickoIme,
            //    Telefon = item.Telefon,
            //    Status = item.Status
            //}));

            result = Mapper.Map(list, result);

            return result;
        }
    }
}
