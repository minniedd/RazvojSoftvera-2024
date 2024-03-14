using Azure.Core;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;

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

        public virtual PagedResult<Model.Korisnici> GetList(KorisniciSearchObject searchObject)
        {
            List<Model.Korisnici> result = new List<Model.Korisnici>();

            var query = Context.Korisnicis.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject?.ImeGTE))
            {
                query = query.Where(x=>x.Ime.StartsWith(searchObject.ImeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.PrezimeGTE))
            {
                query = query.Where(x => x.Prezime.StartsWith(searchObject.PrezimeGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.Email))
            {
                query = query.Where(x => x.Email == searchObject.Email);
            }

            if (!string.IsNullOrWhiteSpace(searchObject?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme == searchObject.KorisnickoIme);
            }

            if (searchObject?.IsKorisniciUlogeIncluded == true)
            {
                query = query.Include(x => x.KorisniciUloges).ThenInclude(x=>x.Uloga);
            }

            int count = query.Count();

            if (!string.IsNullOrWhiteSpace(searchObject.OrderBy))
            {
                query = query.OrderBy(searchObject.OrderBy);
            }

            if (searchObject?.Page.HasValue == true && searchObject?.PageSize.HasValue == true)
            {
                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);
            }
            
            var list = query.ToList();

            result = _mapper.Map(list, result);

            PagedResult<Model.Korisnici> response = new PagedResult<Model.Korisnici>();
            response.PageCount = count;


            return result;
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            if (request.Lozinka != request.LozinkaPotvrda)
            {
                throw new Exception("Lozinka i Lozinka potvrda moraju biti iste!");
            }

            Database.Korisnici entity = new Database.Korisnici();
            _mapper.Map(request, entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);

            Context.Add(entity);
            Context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public static string GenerateSalt()
        {
            var byteArray = RandomNumberGenerator.GetBytes(16);


            return Convert.ToBase64String(byteArray);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = Context.Korisnicis.Find(id);

            _mapper.Map(request, entity);

            if(request.Lozinka != null)
            {
                if (request.Lozinka != request.LozinkaPotvrda)
                {
                    throw new Exception("Lozinka i Lozinka potvrda moraju biti iste!");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            Context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }
    }
}
