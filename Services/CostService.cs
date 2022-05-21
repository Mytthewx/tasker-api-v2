using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskerAPI.Entities;
using TaskerAPI.Models;
using TaskerAPI.Models.ViewModel;
using TaskerAPI.Services.Interfaces;

namespace TaskerAPI.Services
{
    public class CostService : ICostService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CostNotFoundMessage = "Cost with this id doesn't exist.";
        private readonly IMapper _mapper;
        private readonly TaskerContext _db;

        public CostService(IHttpContextAccessor httpContextAccessor, IMapper mapper, TaskerContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _db = db;
        }

        public IEnumerable<CostViewModel> GetAll()
        {
            var costs = _db.Costs.ToList();
            return _mapper.Map<IEnumerable<CostViewModel>>(costs);
        }

        public CostViewModel Get(int id)
        {
            var cost = _db.Costs.FirstOrDefault(x => x.Id == id);
            if (cost == null)
            {
                throw new Exception(CostNotFoundMessage);
            }

            var result = _mapper.Map<CostViewModel>(cost);
            return result;
        }

        public async Task<int> Create(CostViewModel cost)
        {
            var createdCost = _mapper.Map<Cost>(cost);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            createdCost.UserId = int.Parse(userId);
            await _db.Costs.AddAsync(createdCost);
            await _db.SaveChangesAsync();
            return createdCost.Id;
        }

        public bool Delete(int id)
        {
            var cost = _db.Costs.FirstOrDefault(x => x.Id == id);
            if (cost == null)
            {
                return false;
            }

            _db.Costs.Remove(cost);
            _db.SaveChanges();
            return true;
        }

        public Cost Update(int id, CostViewModel costUpdate)
        {
            var cost = _db.Costs.FirstOrDefault(x => x.Id == id);
            if (cost == null)
            {
                throw new Exception(CostNotFoundMessage);
            }

            cost.Label = costUpdate.Label;
            cost.Price = cost.Price;
            cost.DateTime = cost.DateTime;

            _db.SaveChanges();
            return cost;
        }
    }
}
