using System.Collections.Generic;

namespace MovieAplication.WebApi.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        IList<T> GetAll();
        T GetId(int id);
        T AddT(T entity);
        T UpdateT(T entity);
        void DeleteT(int id);


        
    }
}
