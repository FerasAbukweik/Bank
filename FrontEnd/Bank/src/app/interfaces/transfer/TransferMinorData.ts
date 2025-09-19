import { transactionTypesEnums } from "../../enums/transfers";

export interface TransactionModel{
id : number;
amount : number;
createdAt : Date;
TransactionType : transactionTypesEnums;
}