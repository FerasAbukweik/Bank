import { Routes } from '@angular/router';
import { Dashboard } from './components/Pages/dashboard/dashboard';
import { Accounts } from './components/Pages/accounts/accounts';
import { ProfileSettings } from './components/Pages/profile-settings/profile-settings';
import { Transaction } from './components/Pages/transactions/components/transaction/transaction';
import { Transfer } from './components/Pages/transfer/transfer';
import { Transactions } from './components/Pages/transactions/transactions';
import { Login } from './components/Pages/login/login';
import { authGuard } from './guard/Guard';
import { Signup } from './components/Pages/signup/signup';

export const routes: Routes = [
    {path : "" , redirectTo : "/login" , pathMatch : "full"},
    {path : "login" , component : Login},
    {path : "signup" , component : Signup},
    {path : "dashBoard" , component : Dashboard , canActivate : [authGuard]},
    {path : "accounts" , component : Accounts , canActivate : [authGuard]},
    {path : "profile-settings" , component : ProfileSettings , canActivate : [authGuard]},
    {path : "transactions" , component: Transactions , canActivate : [authGuard]},
    {path : "transfers" , component : Transfer , canActivate : [authGuard]}

];
