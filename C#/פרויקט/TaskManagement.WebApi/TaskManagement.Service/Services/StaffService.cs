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
    public class StaffService:IService<StaffDto>
    {
        private readonly IRepository<Staff> repository;
        private readonly IMapper mapper;
        public StaffService(IRepository<Staff> repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }

        public async Task<StaffDto> AddItem(StaffDto item)
        {
            return mapper.Map<StaffDto>(await repository.AddItem(mapper.Map<Staff>(item)));
        }

        public async System.Threading.Tasks.Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<StaffDto>> GetAll()
        {
            return mapper.Map<List<StaffDto>>(await repository.getAll());
        }

        public async Task<StaffDto> GetById(int id)
        {
            return mapper.Map<StaffDto>(await repository.get(id));
        }

        public void UpdateItem(StaffDto item, int id)
        {
            repository.UpdateItem(mapper.Map<Staff>(item), id);
        }
    }
}
