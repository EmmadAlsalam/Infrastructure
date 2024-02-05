using ConsoleApp.Entities;
using ConsoleApp.Repositories;


namespace ConsoleApp.Services
{
    public class ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        private readonly ProductRepository _productRepository = productRepository;
        private readonly CategoryService _categoryService = categoryService;

        public ProductEntity CreateProduct(string title, decimal price, string categoryName)
        {

            var categoryEntity = _categoryService.CreateCategory(categoryName);

            var productEntity = new ProductEntity
            {
                Title = title,
                Price = price,
                CategoryId = categoryEntity.Id,
            };

            productEntity = _productRepository.Create(productEntity);
            return productEntity;
        }



        public ProductEntity GetProductById(int id)
        {
            var productEntity = _productRepository.Get(x => x.Id == id);
            return productEntity;
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        public ProductEntity UpdateProduct(ProductEntity productEntity)
        {
            var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
            return updatedProductEntity;
        }


        public void DeleteProduct(int id)
        {
            _productRepository.Delete(x => x.Id == id);
        }
    }
}
