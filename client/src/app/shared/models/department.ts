export interface IBrand {
  id: number;
  name: string;
  image: string;
  address: string;

}
export interface IType {
  id: number;
  name: string;
  image:string;
  brands: IBrand[];
}
