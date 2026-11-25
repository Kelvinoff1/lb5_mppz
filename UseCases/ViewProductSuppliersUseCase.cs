using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.UseCases;

public class ViewProductSuppliersUseCase
{
    private readonly StoreRepository _repository;

    public ViewProductSuppliersUseCase(StoreRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<Supplier> Execute(int productId)
    {
        var product = _repository.GetProductById(productId)
            ?? throw new InvalidOperationException($"Товар з Id={productId} не знайдено.");

        return product.Suppliers.ToList();
    }
}
