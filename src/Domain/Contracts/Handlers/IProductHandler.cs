using Domain.Commands;
using Domain.Commands.Responses;

namespace Domain.Contracts.Handlers
{
    public interface IProductHandler
    {
        // Write
        GenericResponse Handle(ProductCreateCommand command);
        GenericResponse Handle(ProductUpdateCommand command);
        GenericResponse Handle(ProductPromotionCommand command);
        GenericResponse Handle(ProductDeleteCommand command);
    }
}