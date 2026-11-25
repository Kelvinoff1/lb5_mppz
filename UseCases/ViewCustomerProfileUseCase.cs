using StoreSystem.Data;
using StoreSystem.Models;

namespace StoreSystem.UseCases;

public class ViewCustomerProfileUseCase
{
    private readonly StoreRepository _repository;

    public ViewCustomerProfileUseCase(StoreRepository repository)
    {
        _repository = repository;
    }

    public Customer Execute(int customerId) =>
        _repository.GetCustomerById(customerId)
            ?? throw new InvalidOperationException($"Покупця з Id={customerId} не знайдено.");
}
