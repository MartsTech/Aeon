namespace Cart.Domain.Carts
{
    public interface IItem
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; }
        public DateOnly DateAdded { get; }
        public Guid ListId { get; }
        public Guid UserId { get; }
    }
}
