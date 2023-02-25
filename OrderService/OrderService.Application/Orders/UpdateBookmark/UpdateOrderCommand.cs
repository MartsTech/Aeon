using OrderService.Domain;
using OrderService.Domain.Orders;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace OrderService.Application.Orders.UpdateOrder;

public sealed class UpdateOrderCommand
{
    public class Command : IRequest<Result<bool>>
    {
        public Command(UpdateOrderInput input)
        {
            Input = input;
        }

        public UpdateOrderInput Input { get; }
    }

    private class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new UpdateOrderInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<bool>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IEntityFactory entityFactory, IOrderRepository orderRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();
            
            if (userId == null)
            {
                return Result<bool>.Failure("No user id found");
            }
            
            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);
            
            if (!validation.IsValid)
            {
                return Result<bool>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            bool success = await UpdateQuantity(request.Input.Id, request.Input.Quantity, new Guid(userId), cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<bool>.Success(true)
                : Result<bool>.Failure($"Failed to update order {request.Input.Id}");
        }

        private async Task<bool> UpdateQuantity(Guid id, int quantity, Guid userId, CancellationToken cancellationToken)
        {
            await _orderRepository
                .UpdateOrder(id, quantity, userId)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}