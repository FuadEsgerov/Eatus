import{IProduct} from './product'
import { IBrand } from './brand';
import { IType } from './productType';


export interface IBrandList {
  brand:IBrand;
  products: IProduct;
  types:IType;
}

