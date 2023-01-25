import {pageSlide, pageTransition} from '@common/utils/animations';
import {motion} from 'framer-motion';
import CatalogCategories from './CatalogCategories';
import CatalogProducts from './CatalogProducts';

const CatalogModule = () => {
  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageSlide}
      transition={pageTransition}>
      <CatalogCategories />
      <CatalogProducts />
    </motion.div>
  );
};

export default CatalogModule;
