using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodiController : ControllerBase
    {
        protected IProizvodiServices _service;

        public ProizvodiController(IProizvodiServices service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Proizvodi> GetList([FromQuery]ProizvodiSearchObject searchObject) 
        {
            return _service.GetList(searchObject);
        }
    }
}
