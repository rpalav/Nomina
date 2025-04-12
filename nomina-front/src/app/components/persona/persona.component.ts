import { Component, OnInit } from '@angular/core';
import { IPersona } from 'src/app/entidades/IPersona';
import { PaginacionRequest, PaginacionResponse } from 'src/app/entidades/IPaginacion';
import { PersonaService } from 'src/app/services/persona.service';
import { MensajesService } from 'src/app/services/mensajes.service';

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.sass']
})
export class PersonaComponent implements OnInit {

personas: any[] = [];
  page: number = 1;
  pageSize: number = 5;
  totalItems: number = 0;
  sortField: string = 'IdPersona';
  sortDirection: 'asc' | 'desc' = 'asc';
  totalPages: number = 1;
  searchTerm: string = '';

  constructor(private personaService: PersonaService,
    private _mensajesService: MensajesService) {}

  ngOnInit(): void {
    this.loadPersonas();
  }

  loadPersonas(): void {
    this.personaService
      .filtroPersonas(this.page, this.pageSize, this.sortField, this.sortDirection,
        this.searchTerm)
      .subscribe((response) => {
        this.personas = response.items;
        this.totalItems = response.totalCount;
        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
      });
  }

  changePage(newPage: number): void {
    this.page = newPage;
    this.loadPersonas();
  }

  public sortBy(field: string): void {
    if (this.sortField === field) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortField = field;
      this.sortDirection = 'asc';
    }
    this.loadPersonas();
  }

  onSearch(): void {
    this.page = 1;
    this.loadPersonas();
  }


  deletePersona(id: number): void {
    if (confirm('¿Estás seguro de que deseas eliminar el registro?')) {
      this.personaService.deletePersona(id).subscribe(() => {
        this._mensajesService.Correcto('Gestion de personas', 'Persona eliminada correctamente');
        this.loadPersonas();
      });
    }
  }
}
