import { IType } from './productType';
import { IBrand } from './brand';

export interface IProduct{
  id:number;
  name:string;
  description:string;
  price:number;
  image:string;
  type:IType[];
  brand:IBrand[];
}
