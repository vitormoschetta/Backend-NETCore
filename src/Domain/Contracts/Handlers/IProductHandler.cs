using System;
using Domain.Commands;

namespace Domain.Contracts.Handlers
{
    public interface IProductHandler
    {
        // Write
        CommandResult Handle(ProductCreateCommand command);
        CommandResult Handle(ProductUpdateCommand command);
        CommandResult Handle(ProductPromotionCommand command);
        CommandResult Handle(ProductDeleteCommand command);
    }
}