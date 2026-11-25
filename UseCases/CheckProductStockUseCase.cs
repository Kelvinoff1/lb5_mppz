using StoreSystem.Data;

namespace StoreSystem.UseCases;

public class CheckProductStockUseCase
{
    private readonly StoreRepository _repository;

    public CheckProductStockUseCase(StoreRepository repository)
    {
        _repository = repository;
    }

    public void Execute(int productId, int quantity)
    {
        var product = _repository.GetProductById(productId)
            ?? throw new InvalidOperationException($"Товар з Id={productId} не знайдено.");

        if (!product.HasStock(quantity))
            throw new InvalidOperationException(
                $"Недостатньо товару \"{product.Title}\" на складі (потрібно {quantity}, доступно {product.StockQuantity}).");
    }
}
