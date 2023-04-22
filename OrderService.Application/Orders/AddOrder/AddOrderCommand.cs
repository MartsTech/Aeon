using OrderService.Domain;
using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using OrderService.Application.Wishlists;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Application.Orders.AddOrder;

public sealed class AddOrderCommand
{
    public class Command : IRequest<Result<OrderServiceDto>>
    {
        public Command(AddOrderInput input)
        {
            Input = input;
        }

        public AddOrderInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Input).SetValidator(new AddOrderInputValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<OrderDto>>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderListRepository _orderListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public Handler(IEntityFactory entityFactory, IOrderRepository orderRepository,
            IOrderRepository orderListRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _entityFactory = entityFactory;
            _orderRepository = orderRepository;
            _orderListRepository = orderListRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result<OrderDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userId = _userService.GetCurrentUserId();

            if (userId == null)
            {
                return Result<OrderDto>.Failure("No user id found");
            }

            CommandValidator validator = new CommandValidator();
            ValidationResult validation = await validator.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                return Result<OrderDto>.Failure($"{string.Join('\n', validation.Errors)}");
            }

            OrderList? orderList = await _orderListRepository.GetListById(new Guid(userId), request.Input.ListId).ConfigureAwait(false);
            if (orderList == null)
            {
                return Result<OrderListDto>.Failure($"List {request.Input.ListId} not found");
            }

            Order order =
                _entityFactory.NewOrder(request.Input.ProductId, request.Input.Quantity, request.Input.ListId, new Guid(userId));

            bool success = await CreateBookmark(order, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<OrderDto>.Success(new OrderDto(order))
                : Result<OrderDto>.Failure("Failed to create an order");
        }

        private async Task<bool> CreateOrder(Order order, CancellationToken cancellationToken)
        {
            await _orderRepository
                .AddOrder(order)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}

