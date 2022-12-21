import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { BeneficiarioCadastrarComponent } from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component';
import { BeneficiarioListaComponent } from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { NavComponent } from './Nav/Nav.component';
import { EspecialidadesCadastrarComponent } from './Especialidades/especialidades-cadastrar/especialidades-cadastrar.component';

@NgModule({
  declarations: [
    AppComponent,
    BeneficiarioListaComponent,
    BeneficiarioCadastrarComponent,
    HospitalListaComponent,
    HospitalEditarComponent,
    NavComponent,
    EspecialidadesCadastrarComponent,
  ],

  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
