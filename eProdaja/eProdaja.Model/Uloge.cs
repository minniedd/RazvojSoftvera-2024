using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace eProdaja.Model
{
    public partial class Uloge
    {
        public int UlogaId { get; set; }

        public string Naziv { get; set; } = null!;

        public string? Opis { get; set; }

        [JsonIgnore]
        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; } = new List<KorisniciUloge>();
    }
}
