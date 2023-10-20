using PSIUWeb.Models;

namespace PSIUWeb.Data.Interface
{
    public interface ICategoryRepository
    {
        public Category? GetCategoryById(int id);

        public IQueryable<Category>? GetCategories();

        public Category? Update(Category c);

        public Category? Delete(int id);

        public Category? Create(Category c);
    }
}
