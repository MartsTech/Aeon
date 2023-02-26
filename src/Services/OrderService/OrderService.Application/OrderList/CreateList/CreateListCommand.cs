using Bookmarks.Domain;
using Bookmarks.Domain.Wishlists;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace OrderService.Application.OrderList.CreateList;

public sealed class CreateListCommand
{
    public class Command : IRequest<Result<WishlistDto>>
    {
        public Command(CreateListInput input)
        {
            Input = input;
        }

        public CreateListInput Input { get; }
    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
        }
    }

    public class Handler : IRequestHandler<Command, Result<WishlistDto>>
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

            OrderList list = _entityFactory.NewList(new Guid(userId));

            bool success = await CreateList(list, cancellationToken)
                .ConfigureAwait(false);

            return success
                ? Result<OrderListDto>.Success(new OrderListDto(list))
                : Result<OrderLististDto>.Failure("Failed to create a list");
        }

        private async Task<bool> CreateList(OrderList list, CancellationToken cancellationToken)
        {
            await _OrderListRepository
                .CreateNewList(list)
                .ConfigureAwait(false);

            var changes = await _unitOfWork
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return changes > 0;
        }
    }
}