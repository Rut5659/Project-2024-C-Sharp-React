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
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Service.Services
{
    public class ProjectService : IService<ProjectDto>
    {
        private readonly IRepository<Project> repository;
        private readonly IMapper mapper;
        public ProjectService(IRepository<Project> repository, IMapper _mapper)
        {
            this.repository = repository;
            this.mapper = _mapper;
        }
        public async Task<ProjectDto> AddItem(ProjectDto item)
        {
            return mapper.Map<ProjectDto>(await repository.AddItem(mapper.Map<Project>(item)));
        }

        public async Task DeleteItem(int id)
        {
            await repository.DeleteItem(id);
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            return mapper.Map<List<ProjectDto>>(await repository.getAll());
        }

        public async Task<ProjectDto> GetById(int id)
        {
            return mapper.Map<ProjectDto>(await repository.get(id));
        }

        public void UpdateItem(ProjectDto item, int id)
        {
            repository.UpdateItem(mapper.Map<Project>(item), id);
        }
    }
}
