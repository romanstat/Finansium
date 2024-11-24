// import {
//   HttpErrorResponse,
//   HttpEvent,
//   HttpHandler,
//   HttpInterceptor,
//   HttpRequest,
// } from '@angular/common/http';
// import { catchError, NEVER, Observable, switchMap, throwError } from 'rxjs';
// import { AuthService } from '../../auth/auth.service';

// export class RefreshToken implements HttpInterceptor {
//   constructor(private readonly authService: AuthService) {}

//   intercept(
//     req: HttpRequest<any>,
//     next: HttpHandler
//   ): Observable<HttpEvent<any>> {
//     return next.handle(req).pipe(
//       catchError((error: HttpErrorResponse) => {
//         if (error.status !== 401) {
//           return throwError(() => error);
//         }

//         return this.authService.refreshToken().pipe(
//           catchError(() => {
//             this.authService.logout();
//             return NEVER;
//           }),
//           switchMap(() => {
//             return next.handle(req);
//           })
//         );
//       })
//     );
//   }
// }
