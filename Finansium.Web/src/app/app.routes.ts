import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ProfileComponent } from './modules/profile/profile.component';
import { NotificationComponent } from './modules/notification/notification.component';
import { NewsComponent } from './modules/news/news.component';
import { UsersComponent } from './modules/admin/users/users.component';
import { CountryComponent } from './modules/admin/country/country.component';
import { AnalyticsComponent } from './modules/analytics/analytics.component';
import { AccountComponent } from './modules/finance/account/account.component';
import { SavingsGoalComponent } from './modules/finance/savings-goal/savings-goal.component';
import { CategoryComponent } from './modules/finance/category/category.component';
import { BudgetComponent } from './modules/finance/budget/budget.component';
import { RecurringTransactionComponent } from './modules/finance/recurring-transaction/recurring-transaction.component';

export const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full' },

      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },

      { path: 'profile', component: ProfileComponent },

      { path: 'users', component: UsersComponent },
      { path: 'country', component: CountryComponent },

      { path: 'account', component: AccountComponent },
      { path: 'savings-goal', component: SavingsGoalComponent },
      { path: 'category', component: CategoryComponent },
      { path: 'budget', component: BudgetComponent },
      { path: 'recurring-transaction', component: RecurringTransactionComponent },

      { path: 'analytics', component: AnalyticsComponent },
      { path: 'notification', component: NotificationComponent },
      { path: 'news', component: NewsComponent },
    ],
  },
];
