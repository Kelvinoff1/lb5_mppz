using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.UseCases;

public class ViewProductsByCategoryUseCase
{
    private readonly StoreRepository _repository;

    public ViewProductsByCategoryUseCase(StoreRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<Product> Execute(int categoryId)
    {
        var category = _repository.GetCategoryById(categoryId)
            ?? throw new InvalidOperationException($"Категорію з Id={categoryId} не знайдено.");

        return category.Products;
    }
}
