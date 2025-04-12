import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { SeguridadService } from './services/seguridad.service';

@Injectable({
  providedIn: 'root'
})
export class LoginGuard implements CanActivate {

constructor(private seguridadService: SeguridadService,
  private router: Router) {

}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      if (this.seguridadService.estaLogueado()) {
        return true;
      }
    this.router.navigate(['/login']);
      return false;
  }

}
