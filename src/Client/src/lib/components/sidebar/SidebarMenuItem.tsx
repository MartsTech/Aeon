import Link from 'next/link';
import {useRouter} from 'next/router';
import {FC, useMemo} from 'react';

interface Props {
  sidebarActive: boolean;
  toggleSidebar: () => void;
  Icon: any;
  paths: string[];
  count?: number;
}

const SidebarMenuItem: FC<Props> = ({toggleSidebar, paths, Icon, count}) => {
  const router = useRouter();

  const active = useMemo(() => {
    return paths.some(path => path === router.route);
  }, [router.route, paths]);

  const href = useMemo(() => {
    return paths[0];
  }, [paths]);

  return (
    <Link href={href} passHref>
      <div className="relative my-4 cursor-pointer" onClick={toggleSidebar}>
        <Icon
          className={`h-8 w-8 scale-90 transform
          !text-4xl !transition-all !duration-200 hover:scale-105 ${
            active
              ? 'scale-100 fill-text'
              : '!fill-[transparent] stroke-text stroke-1'
          }`}
        />
        {typeof count != 'undefined' && (
          <span
            suppressHydrationWarning
            className="absolute left-6 bottom-5 h-5
            w-5 rounded-full bg-primary pt-[0.15rem] text-center
            text-xs font-bold text-white">
            {count}
          </span>
        )}
      </div>
    </Link>
  );
};

export default SidebarMenuItem;
