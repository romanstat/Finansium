import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, retry, throwError } from 'rxjs';
import { Constants } from '../constant';
import { AuthService } from '../../auth/auth.service';

export const httpInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);

  if (authService.isLoggedIn()) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem(Constants.AccessToken)}`,
      },
    });

    req = req.clone({
      withCredentials: true,
    });
  }

  return next(req).pipe(
    catchError((e: HttpErrorResponse) => {
      if (e.status === 401) {
        authService.logout();
      }
      return throwError(() => e.error);
    })
  );
};
