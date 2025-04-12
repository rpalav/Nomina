import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { LoaderService } from '../services/loader.service';
import { catchError, finalize } from 'rxjs/operators';
import swal from 'sweetalert2';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(
    ) {}

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
      return next.handle(request).pipe(
        catchError(error => {
          let errorMessage = '';
          if (error.error) {
            if (error.error.codigoError === '003') {
              errorMessage = error.error.mensaje;
            }  else {
              errorMessage = error.error.message;
            }
          }

          swal.fire({
            icon: 'error',
            title: 'Error',
            text: errorMessage == '' ? 'Error en la aplicacion' :  errorMessage,
          });
          return throwError(errorMessage);
        })
      );
    }
}
