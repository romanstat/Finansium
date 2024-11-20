import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ProfileComponent } from './modules/profile/profile.component';
import { NotificationComponent } from './modules/notification/notification.component';
import { NewsComponent } from './modules/news/news.component';
import { UsersComponent } from './modules/admin/users/users.component';
import { CountryComponent } from './modules/admin/country/country.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full' },
      { path: 'profile', component: ProfileComponent },
      { path: 'users', component: UsersComponent },
      { path: 'country', component: CountryComponent },
      { path: 'notification', component: NotificationComponent },
      { path: 'news', component: NewsComponent },
    ],
  },
];
