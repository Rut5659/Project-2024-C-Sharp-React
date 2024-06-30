using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Common.Entities;
using TaskManagement.Repository.Entities;
using TaskManagement.Repository.Interfaces;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Services
{
    public class VacationService : IService<VacationDto>
    {
        private readonly IRepository<Vacation> repository;
        private readonly IMapper mapper;
        public VacationService(IRepository<Vacation> repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }

        public async Task<VacationDto> AddItem(VacationDto item)
        {
            return mapper.Map<VacationDto>(await repository.AddItem(mapper.Map<Vacation>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<VacationDto>> GetAll()
        {
            return mapper.Map<List<VacationDto>>(await repository.getAll());
        }

        public async Task<VacationDto> GetById(int id)
        {
            return mapper.Map<VacationDto>(await repository.get(id));
        }

        public void UpdateItem(VacationDto item, int id)
        {
            repository.UpdateItem(mapper.Map<Vacation>(item), id);
        }
    }
}
