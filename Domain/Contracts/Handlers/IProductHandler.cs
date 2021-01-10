using System;
using Domain.Commands;

namespace Domain.Contracts.Handlers
{
    public interface IProductHandler
    {
        // Write
        CommandResult Create(ProductCreateCommand command);
        CommandResult Update(ProductUpdateCommand command);
        CommandResult AddPromotion(ProductPromotionCommand command);
        CommandResult Delete(string id);
    }
}