using System.ComponentModel.DataAnnotations;
using OrderService.Domain.OrderLists;
using OrderService.Domain;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace OrderService.Application.OrderLists.CreateList;

public sealed class CreateOrderListCommand
{
    public class Command : IRequest<Result<OrderListDto>>
    {
        public Command(CreateOrderListInput input)
        {
            Input = input;
        }

        public CreateOrderListInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
        }
    }

    public class Handler : IRequestHandler<Command, Result<OrderListDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IOrderListRepository _orderListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IEntityFactory entityFactory, IOrderListRepository orderListRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _entityFactory = entityFactory;
            _orderListRepository = orderListRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<OrderListDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            if (userId == null)
            {
                return Result<OrderListDto>.Failure("User is not authenticated");
            }

            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                return Result<OrderListDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            OrderList list = _entityFactory.NewOrderList(new Guid(userId));

            bool success = await CreateList(list, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<OrderListDto>.Success(new OrderListDto(list))
                : Result<OrderListDto>.Failure("Failed to create a list");
        }

        private async Task<bool> CreateList(OrderList list, CancellationToken cancellationToken)
        {
            await _orderListRepository
                .CreateNewList(list)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}

