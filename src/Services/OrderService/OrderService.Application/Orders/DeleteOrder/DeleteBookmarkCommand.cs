using OrderService.Domain.Orders;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace OrderService.Application.Orders.DeleteOrder;

public sealed class DeleteBookmarkCommand
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
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<string>.Failure("No user id found");
            }
            
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validation.IsValid)
            {
                return Result<string>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await DeleteOrder(request.Id, new Guid(userId), cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<string>.Success($"Deleted order {request.Id}")
                : Result<string>.Failure($"Failed to delete order {request.Id}");
        }

        private async Task<bool> DeleteOrder(Guid id, Guid userId, CancellationToken cancellationToken)
        {
            await _orderRepository
                .DeleteOrder(id, userId)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}