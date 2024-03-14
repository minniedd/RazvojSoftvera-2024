using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        protected IKorisniciService _service;

        public KorisniciController (IKorisniciService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Korisnici> GetList([FromQuery]KorisniciSearchObject searchObject)
        {
            return _service.GetList(searchObject);
        }

        [HttpPost]
        public Korisnici Insert(KorisniciInsertRequest request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public Korisnici Update(int id,KorisniciUpdateRequest request)
        {
            return _service.Update(id,request);
        }
    }
}
