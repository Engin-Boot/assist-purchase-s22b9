import { GetAllProductInfo } from '../DataModel/GetAllProduct';
import { IAdmin } from './IAdmin';

export class Admin implements IAdmin{
    getProductInfo: GetAllProductInfo[];
    

}