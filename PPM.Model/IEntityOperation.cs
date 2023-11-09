
namespace PPM.Model
{
    public interface IEntityOperatio<T>
    {
        public void AddEntity(T entity);
        public List<T> ListAll();
        public T ListById(int id);
        public void DeleteById(int id);
    }
}