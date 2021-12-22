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
    public class ClientService : IClientService
    {
        private readonly BankDbContext _context;
        private readonly IMapper _mapper;

        public ClientService(BankDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public async Task<ClientExtended> GetById(int id)
        {
            var question = await _context.Address.FindAsync(id);
            return _mapper.Map<ClientExtended>(question);
        }

        public async Task<IEnumerable<ClientModelBase>> Get()
        {
            var questions = await _context.Client.ToListAsync();
            return _mapper.Map<IEnumerable<ClientModelBase>>(questions);
        }

        public async Task<IEnumerable<ClientExtended>> GetByUserId(int id)
        {
            var answers = await _context.Client
                .Include(a => a.Id)
                .Where(a => a.Id == id).ToListAsync();

            return _mapper.Map<IEnumerable<ClientExtended>>(answers);
        }

        public async Task<ClientModelBase> Insert(ClientCreatedModel model)
        {
            var entity = _mapper.Map<Account>(model);

            await _context.Client.AddAsync(entity);
            await SaveAsync();

            return _mapper.Map<ClientModelBase>(entity);
        }

        public async Task<ClientModelBase> Update(ClientUbdateModel model)
        {
            var entity = await _context.Client.FindAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Client not found");
            }
            _mapper.Map(model, entity);

            _context.Client.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();

            return _mapper.Map<ClientModelBase>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Client.FindAsync(id);
            _context.Client.Remove(entity);
            return await SaveAsync() > 0;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
