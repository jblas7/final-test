using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoWorking.Repositories;
using CoWorking.Service;

namespace CoWorking.Service
{
    public class SalasService : ISalasService
    {
        private readonly ISalasRepository _salasRepository;

        public SalasService(ISalasRepository salasRepository)
        {
            _salasRepository = salasRepository;
        }

        public async Task<List<Salas>> GetAllAsync()
        {
            return await _salasRepository.GetAllAsync();
        }


        public async Task<Salas?> GetByIdAsync(int id)
        {
            return await _salasRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Salas sala)
        {
            await _salasRepository.AddAsync(sala);
        }

        public async Task UpdateAsync(Salas sala)
        {
            await _salasRepository.UpdateAsync(sala);
        }

        public async Task DeleteAsync(int id)
        {
           var sala = await _salasRepository.GetByIdAsync(id);
           if (sala == null)
           {
               //return NotFound();
           }
           await _salasRepository.DeleteAsync(id);
        }


    }
}