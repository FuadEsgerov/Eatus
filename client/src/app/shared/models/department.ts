export interface IBrand {
  id: number;
  name: string;
  image: string;
  address: string;
  detail:string;

}
export interface IType {
  id: number;
  name: string;
  image:string;
  brands: IBrand[];
}
