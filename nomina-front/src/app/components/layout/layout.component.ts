import { Component, OnInit } from '@angular/core';
import { SeguridadService } from 'src/app/services/seguridad.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.sass']
})
export class LayoutComponent implements OnInit {

  isSidebarOpen = false;
  currentComponent = 'dashboard';
  constructor(public seguridadService: SeguridadService) { }

  ngOnInit(): void {
  }


  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }


  closeSidebar() {

  }
  salir(){
    this.seguridadService.logout();
  }
}
