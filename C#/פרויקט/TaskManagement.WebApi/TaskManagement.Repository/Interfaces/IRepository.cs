using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public Task<List<T>> getAll();
        public Task<T> get(int id);
        public Task<T> AddItem(T item);
        public Task UpdateItem(T item, int id);
        public Task DeleteItem(int id);
    }
}
