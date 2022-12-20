import { NgModule } from '@angular/core'
import { RouterModule, Routes } from '@angular/router';
import { BeneficiarioCadastrarComponent} from './Beneficiarios/Beneficiario-Cadastrar/Beneficiario-Cadastrar.component'
import { BeneficiarioListaComponent} from './Beneficiarios/Beneficiario-Lista/Beneficiario-Lista.component'

const routes: Routes = [
  { path: '**', redirectTo: '' },
  { path: 'beneficiariocadastrar', component: BeneficiarioCadastrarComponent },
  { path: 'beneficiariolista', component: BeneficiarioListaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
