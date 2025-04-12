import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IPersona } from 'src/app/entidades/IPersona';
import { PersonaService } from 'src/app/services/persona.service';
import { MensajesService } from 'src/app/services/mensajes.service';

@Component({
  selector: 'app-persona-gestion',
  templateUrl: './persona-gestion.component.html',
  styleUrls: ['./persona-gestion.component.sass']
})
export class PersonaGestionComponent implements OnInit {


  public personaForm: FormGroup;

  constructor(private fb: FormBuilder,
    private personaService: PersonaService,
    private _mensajesService: MensajesService,
    private route: ActivatedRoute) {

    this.personaForm = this.fb.group({
      idPersona: [0, [Validators.required]],
      nombres: ['', [Validators.required, Validators.maxLength(50)]],
      apellidos: ['', [Validators.required, Validators.maxLength(50)]],
      edad: [0, [Validators.required, Validators.min(1)]],
      genero: ['', [Validators.required]],
      fechaNacimiento: [, ],
      lugarNacimiento: ['', [Validators.required] ]
    });
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id && parseInt(id) > 0) {
      this.loadPersona(+id);
    }
  }


  loadPersona(id: number): void {
    this.personaService.getPersona(id).subscribe((response) => {
      this.personaForm.patchValue(response)
    });
  }

  onSubmit(): void {
    if (this.personaForm.valid) {
      const persona = this.personaForm.value as IPersona;
      if(persona.idPersona > 0) {
        this.personaService.updatePersona(persona).subscribe((response) => {
          this._mensajesService.Correcto('Gestion de personas', 'Informacion actulizada correctamente');
        });
      } else {
        this.personaService.createPersona(persona).subscribe((response) => {
          this._mensajesService.Correcto('Gestion de personas', 'Informacion guardada correctamente');
        });
      }
    }
  }

  resetForm(): void {
    this.personaForm.reset();
  }
}
