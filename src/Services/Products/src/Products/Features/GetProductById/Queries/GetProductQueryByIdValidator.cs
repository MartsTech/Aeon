using FluentValidation;

namespace Products.Products.Features.GetProductById.Queries;

public class GetProductQueryByIdValidator: AbstractValidator<GetProductQueryById>
{
    public GetProductQueryByIdValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id).NotNull().WithMessage("Id is required!");
    }
}