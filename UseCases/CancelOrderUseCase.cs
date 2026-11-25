using StoreSystem.Data;
using StoreSystem.Infrastructure;
using StoreSystem.Models;

namespace StoreSystem.UseCases;

public class CancelOrderUseCase
{
    private readonly StoreRepository _repository;
    private readonly IAuditLog _log;

    public CancelOrderUseCase(StoreRepository repository, IAuditLog log)
    {
        _repository = repository;
        _log = log;
    }

    public Order Execute(int orderId)
    {
        var order = _repository.GetOrderById(orderId)
            ?? throw new InvalidOperationException($"Замовлення з Id={orderId} не знайдено.");

        order.Cancel(); 

        _log.Info($"UC-11: скасовано замовлення #{orderId}, товари повернено на склад (стан: Скасоване)");
        return order;
    }
}
