interface ProductObj
{
    id?: number;
    name: string;
    price: number;
    count: number;
    idCompany: number;
    company: string;
    idTypeProduct?: number;
    typeProduct?: string;
    countCores?:number;
    countStreams?: number;
    frequency?: number;
    idSocket?: number;
    countMemory?: number;
    idTypeMemory?: number;
    idFormFactor?: number;
    catalogString: string;
} 

export default ProductObj;