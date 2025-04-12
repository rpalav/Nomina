import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICredenciales, IRespuestaAutenticacion } from '../entidades/ISeguridad';

@Injectable({
  providedIn: 'root'
})
export class SeguridadService {

  apiUrl = environment.apiURL + '/Auth' ;
  private readonly llaveToken = 'token';
  private readonly tiempoExpiracion ='tiempoExpiracion';
  constructor(private httpClient: HttpClient,
    private router: Router) { }


  login(credenciales: ICredenciales): Observable<IRespuestaAutenticacion>{
    return this.httpClient.post<IRespuestaAutenticacion>(this.apiUrl+ '/login', credenciales);
  }

  logout(){
    localStorage.removeItem(this.llaveToken);
    localStorage.removeItem(this.tiempoExpiracion);
    this.router.navigate(['/login']);
  }


  guardarToken(respuesta: IRespuestaAutenticacion): void{
    localStorage.setItem(this.llaveToken,  respuesta.accessToken);
    localStorage.setItem(this.tiempoExpiracion,  respuesta.expireIn.toString());
  }

  obtenerToken(): any{
    return localStorage.getItem(this.llaveToken);
  }


  estaLogueado(): boolean {
    const token = localStorage.getItem(this.llaveToken);
    if (!token) {
      return false;
    }

    return true;

  }


}

