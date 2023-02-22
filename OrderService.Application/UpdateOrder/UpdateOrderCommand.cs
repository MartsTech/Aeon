using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderService.Domain;
using OrderService.Domain.Bookmarks;
using BuildingBlocks.Authentication;
using BuildingBlocks.Core;
using BuildingBlocks.EFCore;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace OrderService.Application.UpdateOrder
{
    public sealed class UpdateServiceCommand
    {
        public class Command : IRequest<Result<bool>>
        {
            public Command(UpdateServiceInput input)
            {
                Input = input;
            }

            public UpdateServiceInput Input { get; }
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
            

            public Handler(IEntityFactory entityFactory, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
            {
                _orderRepository = orderRepository;
                _unitOfWork = unitOfWork;
                
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
             

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
}
