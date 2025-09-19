export interface User{
    id : number;
    userName : string;
    hashedPassword : string;
    email : string;
    phone : string;
    createdAt : Date;
    BankRole_id : number;
}