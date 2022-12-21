import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { BeneficiarioEditarComponent } from './Beneficiarios/Beneficiario-editar/Beneficiario-editar.component';
import { BeneficiarioListaComponent } from './Beneficiarios/Beneficiario-lista/Beneficiario-lista.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { ProfissionalEditarComponent } from './Profissional/Profissional-editar/profissional-editar.component';
import { ProfissionalListaComponent } from './Profissional/Profissional-lista/profissional-lista.component';
import { NavComponent } from './Nav/Nav.component';

@NgModule({
  declarations: [
    AppComponent,
    BeneficiarioListaComponent,
    BeneficiarioEditarComponent,
    ProfissionalEditarComponent,
    ProfissionalListaComponent,
    HospitalListaComponent,
    HospitalEditarComponent,
    NavComponent
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
