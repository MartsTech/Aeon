using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain
{
    public interface IBookmark
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; }
        public DateOnly DateAdded { get; }
        public Guid ListId { get; }
        public Guid UserId { get; }
    }
