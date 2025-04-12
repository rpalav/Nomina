import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPersona } from '../entidades/IPersona';
import { PaginacionRequest, PaginacionResponse } from '../entidades/IPaginacion';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  private apiUrl = environment.apiURL + '/Persona';
  constructor(private http: HttpClient) { }

  getPersonas(): Observable<IPersona[]>{
    return this.http.get<IPersona[]>(this.apiUrl);
  }

  getPersona(idPersona: number): Observable<IPersona>{
      return this.http.get<IPersona>(`${this.apiUrl}/${idPersona}`);
  }

  createPersona(persona: IPersona): Observable<IPersona>{
    return this.http.post<IPersona>(this.apiUrl, persona);
  }

  updatePersona(persona: IPersona): Observable<void>{
    return this.http.put<void>(`${this.apiUrl}/${persona.idPersona}`, persona);
  }

  deletePersona(idPersona: number): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${idPersona}`)
  }

  filtroPersonas(
    page: number,
    pageSize: number,
    sortField: string,
    sortDirection: string,
    searchTerm: string
  ): Observable<any> {
    const params = {
      page: page.toString(),
      pageSize: pageSize.toString(),
      filter:searchTerm,
      sortField,
      sortDirection
    };
    return this.http.post<any>(`${this.apiUrl}/GetPersonas`, params);
  }
}

