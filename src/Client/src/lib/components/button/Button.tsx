import type {ButtonHTMLAttributes, DetailedHTMLProps} from 'react';

interface ButtonProps
  extends DetailedHTMLProps<
    ButtonHTMLAttributes<HTMLButtonElement>,
    HTMLButtonElement
  > {
  variant: 'primary' | 'secondary' | 'outlined' | 'red';
}

const Button: React.FC<ButtonProps> = ({
  children,
  disabled = false,
  variant,
  className,
  ...props
}) => {
  return (
    <button
      disabled={disabled}
      className={`flex transform items-center justify-center rounded-lg
       border-none py-3 px-6 font-bold text-white
       transition-all duration-200 focus:outline-none
       active:scale-95
    ${disabled && 'opacity-50 hover:scale-100 '}
    ${className} ${
        variant == 'primary'
          ? 'bg-primary hover:scale-105'
          : variant == 'secondary'
          ? 'bg-[#1a1a2c] hover:scale-105'
          : variant == 'outlined'
          ? '!border-2 !border-solid !border-gray-300 bg-none font-medium text-gray-400'
          : variant === 'red'
          ? 'ml-2 h-6 rounded-md border-none bg-red-600 text-white'
          : 'none'
      }`}
      style={{
        boxShadow:
          variant == 'primary'
            ? '0 0.5rem 1rem rgba(255, 153, 0, 0.25)'
            : variant == 'secondary'
            ? '0 0.5rem 1rem rgba(26, 26, 44, 0.25)'
            : '0 0.5rem 1rem rgba(26, 26, 44, 0.1)',
      }}
      {...props}>
      {children}
    </button>
  );
};

export default Button;
