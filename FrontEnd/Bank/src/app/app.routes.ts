import { Routes } from '@angular/router';
import { Dashboard } from './components/Pages/dashboard/dashboard';
import { Accounts } from './components/Pages/accounts/accounts';
import { ProfileSettings } from './components/Pages/profile-settings/profile-settings';
import { Transaction } from './components/Pages/transactions/components/transaction/transaction';
import { Transfer } from './components/Pages/transfer/transfer';
import { Transactions } from './components/Pages/transactions/transactions';

export const routes: Routes = [
    {path : "" , redirectTo : "/dashBoard" , pathMatch : "full"},
    {path : "dashBoard" , component : Dashboard},
    {path : "accounts" , component : Accounts},
    {path : "profile-settings" , component : ProfileSettings},
    {path : "transactions" , component: Transactions},
    {path : "transfers" , component : Transfer}

];
