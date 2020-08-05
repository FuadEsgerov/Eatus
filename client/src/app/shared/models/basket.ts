import {v4 as uuidv4} from 'uuid';
import { IBrand } from './brand';
import { IType } from './productType';

export interface IBasket {
  id: string;
  items: IBasketItem[];
  clientSecret?: string;
  paymentIntentId?: string;
  deliveryMethodId?: number;
  shippingPrice?: number;
}

export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: IBrand['name'];
    type: IType['name'];
}

export class Basket implements IBasket {
    id = uuidv4();
    items: IBasketItem[] = [];
}

export interface IBasketTotals {
    shipping: number;
    subtotal: number;
    total: number;
}
