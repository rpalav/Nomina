import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ICredenciales } from 'src/app/entidades/ISeguridad';
import { SeguridadService } from 'src/app/services/seguridad.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private fb: FormBuilder,
              private router: Router,
              private _seguridadService: SeguridadService) {
    this.loginForm = this.fb.group({
      usuario: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const credenciales = this.loginForm.value as ICredenciales;
      console.log('Formulario enviado:', this.loginForm.value);
      this._seguridadService.login(credenciales).subscribe(resp => {
        this._seguridadService.guardarToken(resp);
        this.router.navigate(['/persona']);
      })
    }
  }


}
