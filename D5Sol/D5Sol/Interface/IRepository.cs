using System.Collections.Generic;
using System.Threading.Tasks;

namespace D5Sol.Interface
{
    public interface IRepository<T>
    {
        public void CreateJob(T _object);

        public void UpdateJob(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public void DeleteJob(T _object);

    }
}
