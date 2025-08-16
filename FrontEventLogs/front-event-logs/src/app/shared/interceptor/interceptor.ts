import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http'; // agrega HttpInterceptor
import { inject, Injectable } from '@angular/core';
import { ToastModule } from 'primeng/toast';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable({
    providedIn: 'root'
})
export class Interceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const clonedReq = req.clone({
            setHeaders: {
                'tipo': '1'
            }
        });
        return next.handle(clonedReq).pipe(
            catchError(err => {
                console.error('HTTP error:', err);
                return throwError(() => err);
            })
        );
    }
}
