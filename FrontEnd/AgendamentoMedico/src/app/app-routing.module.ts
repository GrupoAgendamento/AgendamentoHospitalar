import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioCadastrarComponent} from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component'
import { BeneficiarioEditarComponent } from './Beneficiarios/Beneficiario-Editar/Beneficiario-Editar.component';
import { BeneficiarioListaComponent} from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component'
import { HospitalEditarComponent } from './hospital/hospital-editar/hospital-editar.component';
import { HospitalListaComponent } from './hospital/hospital-lista/hospital-lista.component';

const routes: Routes = [
  { path: 'beneficiariocadastrar', component: BeneficiarioCadastrarComponent },
  { path: 'beneficiarioeditar/:id', component: BeneficiarioEditarComponent },
  { path: 'beneficiariolista', component: BeneficiarioListaComponent },
  { path: 'hospitalcadastrar', component: HospitalEditarComponent },
  { path: 'hospitallista', component: HospitalListaComponent },
  { path: 'hospitalcadastrar/:id', component: HospitalEditarComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
