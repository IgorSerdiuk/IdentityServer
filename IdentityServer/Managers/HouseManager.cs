using IdentityServer.Data;
using IdentityServer.Data.Models;
using IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityServer.Managers
{
    public class HouseManager : IHouseManager
    {
        private readonly IHouseRepository _houseRepository;
        
        public HouseManager(IHouseRepository houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public IEnumerable<CageModel> GetAll()
        {
            return _houseRepository.GetAll().Select(x=>new CageModel());
        }
    }

    public interface IHouseManager
    {
        IEnumerable<CageModel> GetAll();
    }

    public class HouseRepository : IHouseRepository
    {
        private readonly IdentityServerContext _context;
        public HouseRepository(IdentityServerContext context)
        {
            _context = context;
        }

        public IEnumerable<Cage> GetAll()
        {
            return _context.Cages.AsNoTracking().ToList();
        }
    }

    public interface IHouseRepository
    {
        IEnumerable<Cage> GetAll();
    }
}