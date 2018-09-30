using System.Linq;

namespace AnoraksAlmanacDAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All
        {
            get;
        }

        TEntity Find(int key);

        void Add(params TEntity[] obj);

        void Edit(params TEntity[] obj);

        void Remove(params TEntity[] obj);
    }
}