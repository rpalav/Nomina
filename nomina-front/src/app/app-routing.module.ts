import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { LoginGuard } from './login.guard';
import { PersonaComponent } from './components/persona/persona.component';
import { PersonaGestionComponent } from './components/persona/persona-gestion/persona-gestion.component';

const routes: Routes = [
  {
    path:'',
    component: LoginComponent
  },
  {
    path:'login',
    component: LoginComponent
  }, 
  {
    path:'persona',
    component: PersonaComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'persona/gestion/:id',
    component: PersonaGestionComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'main',
    component: LayoutComponent,
    canActivate:[LoginGuard]
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
