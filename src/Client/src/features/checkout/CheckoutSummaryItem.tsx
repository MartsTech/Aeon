interface Props {
  title: string;
  price: string | number;
  quantity?: string;
  total?: boolean;
}

const CheckoutSummaryItem: React.FC<Props> = ({
  title,
  price,
  quantity,
  total,
}) => {
  return (
    <div className="flex w-full items-end overflow-hidden">
      <span className="truncate" suppressHydrationWarning>
        {title}
      </span>
      {quantity && <small className="pl-1 opacity-50">{quantity}</small>}
      <span className="ml-auto whitespace-nowrap pl-4">
        {total ? (
          <strong className="text-xl font-black">
            <small>$</small>
            {price}
          </strong>
        ) : (
          <>
            <small>$</small>
            {price}
          </>
        )}
      </span>
    </div>
  );
};

export default CheckoutSummaryItem;
