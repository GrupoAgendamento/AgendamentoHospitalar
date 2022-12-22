import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
//import { BeneficiarioListaComponent} from './Beneficiarios/Beneficiario-lista/Beneficiario-lista.component'
import { BeneficiarioCadastrarComponent} from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component'
import { BeneficiarioEditarComponent} from './Beneficiarios/Beneficiario-Editar/Beneficiario-Editar.component'
import { BeneficiarioListaComponent} from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component'
import { EspecialidadesCadastrarComponent } from './Especialidades/especialidades-cadastrar/especialidades-cadastrar.component';
import { EspecialidadesEditarComponent } from './Especialidades/especialidades-editar/especialidades-editar.component';
import { HospitalCadastrarComponent } from './hospital/hospital-cadastrar/hospital-cadastrar.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { ProfissionalCadastrarComponent } from './Profissional/Profissional-cadastrar/profissional-cadastrar.component';
import { ProfissionalListaComponent } from './Profissional/Profissional-lista/profissional-lista.component';
import { ProfissionalEditarComponent } from './Profissional/Profissional-editar/profissional-editar.component';
import { AgendarComponent } from './Agendamento/agendar/agendar.component';
import { ConsultarComponent } from './Agendamento/consultar/consultar.component';

const routes: Routes = [
  { path: 'beneficiariocadastrar', component: BeneficiarioEditarComponent },
  { path: 'beneficiariocadastrar/:id', component: BeneficiarioEditarComponent },
  //{ path: 'beneficiariolista', component: BeneficiarioListaComponent },
  { path: 'hospitalcadastrar', component: HospitalEditarComponent },
  { path: 'hospitalcadastrar/:id', component: HospitalEditarComponent },
  { path: 'beneficiariocadastrar', component: BeneficiarioCadastrarComponent },
  { path: 'beneficiarioeditar/:id', component: BeneficiarioEditarComponent },
  { path: 'beneficiariolista', component: BeneficiarioListaComponent },
  { path: 'hospitaleditar/:id', component: HospitalEditarComponent },
  { path: 'hospitalcadastrar', component: HospitalCadastrarComponent },
  { path: 'hospitallista', component: HospitalListaComponent },
  { path: 'profissionalcadastrar', component: ProfissionalCadastrarComponent },
  { path: 'profissionallista', component: ProfissionalListaComponent },
  { path: 'profissionaleditar/:id', component: ProfissionalEditarComponent },
  { path: 'profissionalcadastrar/:id', component: ProfissionalEditarComponent },
  { path: 'especialidadescadastrar', component: EspecialidadesCadastrarComponent},
  { path: 'especialidadescadastrar/:id', component: EspecialidadesCadastrarComponent},
  { path: 'especialidadeseditar/:id', component: EspecialidadesEditarComponent },
  { path: '', component: AgendarComponent },
  { path: 'agendamentoconsultar', component: ConsultarComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
