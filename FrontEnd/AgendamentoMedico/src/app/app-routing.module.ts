import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioCadastrarComponent} from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component'
import { BeneficiarioEditarComponent} from './Beneficiarios/Beneficiario-Editar/Beneficiario-editar.component'
import { BeneficiarioListaComponent} from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component'
import { EspecialidadesCadastrarComponent } from './Especialidades/especialidades-cadastrar/especialidades-cadastrar.component';
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';
import { ProfissionalEditarComponent } from './Profissional/Profissional-editar/profissional-editar.component';
import { ProfissionalListaComponent } from './Profissional/Profissional-lista/profissional-lista.component';
import { EspecialidadesEditarComponent } from './Especialidades/especialidades-editar/especialidades-editar.component';



const routes: Routes = [
  { path: 'beneficiariocadastrar', component: BeneficiarioCadastrarComponent },
  { path: 'beneficiarioeditar/:id', component: BeneficiarioEditarComponent },
  { path: 'beneficiariolista', component: BeneficiarioListaComponent },
  { path: 'hospitalcadastrar', component: HospitalEditarComponent },
  { path: 'hospitalcadastrar/:id', component: HospitalEditarComponent },
  { path: 'hospitallista', component: HospitalListaComponent },
  { path: 'profissionalcadastrar', component: ProfissionalEditarComponent },
  { path: 'profissionallista', component: ProfissionalListaComponent },
  { path: 'profissionalcadastrar/:id', component: ProfissionalEditarComponent },
  { path: 'profissionallista', component: ProfissionalListaComponent },
  { path: 'especialidadescadastrar', component: EspecialidadesCadastrarComponent},
  { path: 'especialidadescadastrar/:id', component: EspecialidadesCadastrarComponent},
  { path: 'especialidadeseditar/:id', component: EspecialidadesEditarComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
