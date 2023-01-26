import FooterContacts from './FooterContacts';
import FooterDisclaimer from './FooterDisclaimer';

const Footer = () => {
  return (
    <footer
      className="mx-auto mt-auto flex w-full flex-col 
      bg-accent sm:pl-24">
      <FooterDisclaimer />
      <FooterContacts />
    </footer>
  );
};

export default Footer;
