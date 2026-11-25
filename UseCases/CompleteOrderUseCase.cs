using StoreSystem.Data;
using StoreSystem.Infrastructure;
using StoreSystem.Models;

namespace StoreSystem.UseCases;

public class CompleteOrderUseCase
{
    private readonly StoreRepository _repository;
    private readonly IAuditLog _log;

    public CompleteOrderUseCase(StoreRepository repository, IAuditLog log)
    {
        _repository = repository;
        _log = log;
    }

    public Order Execute(int orderId)
    {
        var order = _repository.GetOrderById(orderId)
            ?? throw new InvalidOperationException($"Замовлення з Id={orderId} не знайдено.");

        order.Complete(); 

        _log.Info($"UC-10: замовлення #{orderId} видано покупцю (стан: Видане)");
        return order;
    }
}
