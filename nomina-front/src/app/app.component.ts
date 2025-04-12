import { Component } from '@angular/core';
import { SeguridadService } from './services/seguridad.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
    constructor(public _seguridadService: SeguridadService) {
      

    }
}
