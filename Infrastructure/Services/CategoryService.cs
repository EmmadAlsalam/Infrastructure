using ConsoleApp.Entities;
using ConsoleApp.Repositories;


namespace ConsoleApp.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryEntity CreateCategory(string categoryName)
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            categoryEntity ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

            return categoryEntity;
        }

        public CategoryEntity GetCategoryByCategoryName(string categoryName)
        {
            var categoryEntity = _categoryRepository.Get(x => x.CategoryName == categoryName);
            return categoryEntity;
        }

        public CategoryEntity GetCategoryById(int id)
        {
            var categoryEntity = _categoryRepository.Get(x => x.Id == id);
            return categoryEntity;
        }

        public IEnumerable<CategoryEntity> GetCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories;
        }

        public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
        {
            var updatedCategoryEntity = _categoryRepository.Update(x => x.Id == categoryEntity.Id, categoryEntity);
            return updatedCategoryEntity;
        }

        public void DeleteCategory(int id)
        {
            try
            {
                _categoryRepository.Delete(x => x.Id == id);
            }
            catch (Exception ex)
            {
                // Hantera eller logga felet här
                Console.WriteLine($"Ett fel uppstod vid radering av kategorin med id {id}: {ex.Message}");
                // Du kan också kasta om felet om du vill att det ska hanteras på en högre nivå
                throw;
            }
        }

    }
}
