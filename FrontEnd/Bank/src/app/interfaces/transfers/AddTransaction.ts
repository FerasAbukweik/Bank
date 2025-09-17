export interface AddTransaction{
    amount : number;
    transactionType : number;
    fromAccount_id : number | null;
    toAccount_id : number | null;
    fromUserId : number | null;
    toUserId : number | null;
}