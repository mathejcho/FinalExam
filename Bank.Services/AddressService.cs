using AutoMapper;
using Bank.Data;
using Bank.Data.Entities;
using Bank.Models.Modles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
   public class AddressService : IAddressService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;

        public AddressService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AddressExtended> GetAddressById(int id)
        {
            var question = await _context.Address.FindAsync(id);
            return _mapper.Map<AddressExtended>(question);
        }

        public async Task<IEnumerable<AddressModelBase>> Get()
        {
            var questions = await _context.Address.ToListAsync();
            return _mapper.Map<IEnumerable<AddressModelBase>>(questions);
        }

        public async Task<IEnumerable<AddressExtended>> GetByUserId(int id)
        {
            var answers = await _context.Address
                .Include(a => a.Id)
                .Where(a => a.Id == id).ToListAsync();

            return _mapper.Map<IEnumerable<AddressExtended>>(answers);
        }

        public async Task<AddressModelBase> Insert(AddressCreatedModel model)
        {
            var entity = _mapper.Map<Account>(model);

            await _context.Address.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<AddressModelBase>(entity);
        }

        public async Task<AddressModelBase> Update(AddressUpdateModel model)
        {
            var entity = await _context.Address.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Address not found");
            }
            _mapper.Map(model, entity);

            _context.Address.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<AddressModelBase>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Address.FindAsync(id);
            _context.Address.Remove(entity);
            return await SaveAsync() > 0;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        }
    }

