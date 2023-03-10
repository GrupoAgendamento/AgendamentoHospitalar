import { AgendamentoCadastrarComponent } from './Agendamento/agendar/agendar.component';
import { ProfissionalCadastrarComponent } from './Profissional/Profissional-cadastrar/profissional-cadastrar.component';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { BeneficiarioEditarComponent } from './Beneficiarios/Beneficiario-Editar/Beneficiario-Editar.component';
import { BeneficiarioListaComponent } from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { ProfissionalEditarComponent } from './Profissional/Profissional-editar/profissional-editar.component';
import { ProfissionalListaComponent } from './Profissional/Profissional-lista/profissional-lista.component';
import { NavComponent } from './Nav/Nav.component';
import { BeneficiarioCadastrarComponent } from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component';
import { HospitalCadastrarComponent } from './hospital/hospital-cadastrar/hospital-cadastrar.component';
import { EspecialidadesCadastrarComponent } from './Especialidades/especialidades-cadastrar/especialidades-cadastrar.component';
import { EspecialidadesEditarComponent } from './Especialidades/especialidades-editar/especialidades-editar.component';

@NgModule({
  declarations: [
    AppComponent,
    BeneficiarioListaComponent,
    BeneficiarioEditarComponent,
    BeneficiarioListaComponent,
    BeneficiarioCadastrarComponent,
    HospitalListaComponent,
    HospitalEditarComponent,
    ProfissionalCadastrarComponent,
    ProfissionalListaComponent,
    ProfissionalEditarComponent,
    HospitalCadastrarComponent,
    EspecialidadesCadastrarComponent,
    EspecialidadesEditarComponent,
    NavComponent,
    AgendamentoCadastrarComponent
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
