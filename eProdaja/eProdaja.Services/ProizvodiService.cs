using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService:IProizvodiServices
    {
        public EProdajaContext Context { get; set; }
        public IMapper _mapper;

        public ProizvodiService(EProdajaContext context,IMapper mapper) 
        {
            Context = context;
            _mapper = mapper;
        }

        public virtual List<Model.Proizvodi> GetList(ProizvodiSearchObject searchObject)
        {
            List<Model.Proizvodi> result = new List<Model.Proizvodi>();

            var query = Context.Proizvodis.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.FTS))
            {
                query = query.Where(x => x.Naziv.Contains(searchObject.FTS) || x.Sifra.Contains(searchObject.FTS));
            }

            if (searchObject?.Page.HasValue == true && searchObject?.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
            }

            var list = query.ToList();

            result = _mapper.Map(list, result);

            return result;
        }
    }
}
