import { IType } from './productType';
import { IBrand } from './brand';

export interface IProduct{
  id:number;
  name:string;
  description:string;
  price:number;
  pictureUrl:string;
  type:IType[];
  brand:IBrand[];
}
