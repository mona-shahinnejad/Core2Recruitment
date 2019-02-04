using System.Collections.Generic;

namespace SIENN.Services.IServices
{
    public interface IBaseCRUDService<T> where T : class
    {
        bool Add(T unit);

        bool Update(T unit);

        bool Delete(T unit);

        T Find(string code);

        IEnumerable<T> FindByName(string name);

        IEnumerable<T> GeTAll();
    }
}
