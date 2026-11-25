using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.UseCases;

public class ViewCustomerOrdersUseCase
{
    private readonly StoreRepository _repository;

    public ViewCustomerOrdersUseCase(StoreRepository repository)
    {
        _repository = repository;
    }

    public IReadOnlyList<Order> Execute(int customerId)
    {
        var customer = _repository.GetCustomerById(customerId)
            ?? throw new InvalidOperationException($"Покупця з Id={customerId} не знайдено.");

        return customer.Orders.OrderBy(o => o.OrderDate).ToList();
    }
}
