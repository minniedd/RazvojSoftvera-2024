using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Model.SearchObjects
{
    public class KorisniciSearchObject
    {
        public string? ImeGTE { get; set; }

        public string? PrezimeGTE {  get; set; }

        public string? Email { get; set; }

        public string? KorisnickoIme { get; set; }

        public bool? IsKorisniciUlogeIncluded { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public string OrderBy { get; set; }
    }
}
