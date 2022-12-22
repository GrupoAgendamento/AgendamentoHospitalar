import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioCadastrarComponent} from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component'
import { BeneficiarioEditarComponent} from './Beneficiarios/Beneficiario-Editar/Beneficiario-Editar.component'
import { BeneficiarioListaComponent} from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component'
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';
import { ProfissionalEditarComponent } from './Profissional/Profissional-editar/profissional-editar.component';
import { ProfissionalListaComponent } from './Profissional/Profissional-lista/profissional-lista.component';
import { AgendarComponent } from './Agendamento/agendar/agendar.component';
import { ConsultarComponent } from './Agendamento/consultar/consultar.component';

const routes: Routes = [
  { path: 'beneficiariocadastrar', component: BeneficiarioCadastrarComponent },
  { path: 'beneficiarioeditar/:id', component: BeneficiarioEditarComponent },
  { path: 'beneficiariolista', component: BeneficiarioListaComponent },
  { path: 'hospitalcadastrar', component: HospitalEditarComponent },
  { path: 'hospitalcadastrar/:id', component: HospitalEditarComponent },
  { path: 'hospitallista', component: HospitalListaComponent },
  { path: 'profissionalcadastrar', component: ProfissionalEditarComponent },
  { path: 'profissionallista', component: ProfissionalListaComponent },
  { path: '', component: AgendarComponent },
  { path: 'agendamentoconsultar', component: ConsultarComponent },
  { path: 'profissionalcadastrar/:id', component: ProfissionalEditarComponent },
  { path: 'profissionallista', component: ProfissionalListaComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
