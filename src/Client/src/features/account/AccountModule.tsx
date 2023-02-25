import {authProfileSelector, authUserSelector} from '@features/auth/auth-state';
import Button from '@lib/components/button/Button';
import {useStoreSelector} from '@lib/store/store-hooks';
import Image from 'next/image';
import Link from 'next/link';

const AccountModule = () => {
  const user = useStoreSelector(authUserSelector);
  const profile = useStoreSelector(authProfileSelector);

  if (typeof user === 'undefined') {
    return null;
  }

  return (
    <div className="px-6 pt-12 md:p-12">
      <div className="flex flex-col items-center self-start md:flex-row">
        <div className="flex w-full items-center md:w-auto">
          <div className="relative h-20 w-20 md:h-24 md:w-24">
            <Image
              src={user.image || '/images/default.jpg'}
              alt="avatar"
              className="absolute mr-6 rounded-full object-contain shadow-sm"
              fill
            />
          </div>
          <div className="flex md:hidden" style={{marginLeft: 'auto'}}>
            <Link href="logout">
              <Button className="h-10 py-4 px-6" variant="red">
                Sign Out
              </Button>
            </Link>
          </div>
        </div>
        <div className="mt-12 md:ml-6 md:max-w-[340px] lg:max-w-none">
          <h3
            className="text-xl font-semibold md:text-2xl"
            style={{fontSize: 'calc(1.3rem + .6vw)'}}>
            Hi, {user.name}
          </h3>
          <p className="mb-8 text-base opacity-50 md:max-w-md">
            This is your profile page. Here, you can view and customize your
            profile details. Double check your details before check out.
          </p>
        </div>
        <div
          className="ml-auto hidden md:ml-auto md:flex"
          style={{marginLeft: 'auto'}}>
          <Link href="logout">
            <Button className="h-10 py-4 px-6" variant="red">
              Sign Out
            </Button>
          </Link>
        </div>
      </div>
      <div className="mt-12 space-y-2 rounded-lg bg-white p-4 shadow-lg md:space-y-4 md:p-8 md:p-12">
        <p className="flex pb-4">
          <span className="profile__label">Name</span>
          <span className="flex-[80%]">{user.name}</span>
        </p>
        <p className="flex">
          <span className="profile__label">Email Address</span>
          <span className="flex-[80%]">{user.email}</span>
        </p>
        <p className="flex">
          <span className="profile__label">Given Name</span>
          <span className="flex-[80%]">{profile?.givenName}</span>
        </p>
        <p className="flex">
          <span className="profile__label">Family Name</span>
          <span className="flex-[80%]">{profile?.familyName}</span>
        </p>
        <p className="flex">
          <span className="profile__label">Country</span>
          <span className="flex-[80%]">{profile?.country}</span>
        </p>
        <p className="flex">
          <span className="profile__label">City</span>
          <span className="flex-[80%]">{profile?.city}</span>
        </p>
        <p className="flex">
          <span className="profile__label">Postal Code</span>
          <span className="flex-[80%]">{profile?.postalCode}</span>
        </p>
        <p className="flex">
          <span className="profile__label">State</span>
          <span className="flex-[80%]">{profile?.state}</span>
        </p>
        <p className="flex">
          <span className="profile__label">Street Address</span>
          <span className="flex-[80%]">{profile?.streetAddress}</span>
        </p>
      </div>
    </div>
  );
};

export default AccountModule;
