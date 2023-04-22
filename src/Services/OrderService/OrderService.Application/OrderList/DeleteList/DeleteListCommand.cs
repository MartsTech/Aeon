using OrderService.Domain.Wishlists;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Application.OrderList.DeleteList;

public sealed class DeleteListCommand
{
    public class Command : IRequest<Result<string>>
    {
        public Command(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }

    public class Handler : IRequestHandler<Command, Result<string>>
    {
        private readonly IOrderListRepository _OrderListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IOrderListRepository orderLististRepository, IUnitOfWork unitOfWork)
        {
            _orderListRepository = orderListRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await DeleteList(request.Id, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted empty order list {request.Id}")
                : Result<string>.Failure($"Failed to delete order list {request.Id}: not found or not empty!");
        }

        private async Task<bool> DeleteList(Guid id, CancellationToken cancellationToken)
        {
            await _orderListRepository
                .DeleteList(id)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}
