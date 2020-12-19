using System;
using Domain.Commands;

namespace Domain.Contracts.Handlers
{
    public interface IProductHandler
    {
        // Write
        CommandResult Create(CreateProductCommand command);
        CommandResult Update(UpdateProductCommand command);
        CommandResult AddPromotion(AddPromotionProductCommand command);
        CommandResult Delete(Guid id);
    }
}