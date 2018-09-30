using System.Linq;

namespace AnoraksAlmanacDAL
{
    public class RepositorioBaseEF<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AnoraksAlmanacContext _context;

        public RepositorioBaseEF(AnoraksAlmanacContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> All => _context.Set<TEntity>().AsQueryable();

        public void Add(params TEntity[] obj)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(params TEntity[] obj)
        {
            throw new System.NotImplementedException();
        }

        public TEntity Find(int key)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(params TEntity[] obj)
        {
            throw new System.NotImplementedException();
        }
    }
}