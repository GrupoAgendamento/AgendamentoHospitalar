import { Component } from "@angular/core";
import { IBeneficiarioDto } from "src/app/interfaces/IBeneficiarioDto";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs';

@Component({
    selector: 'app-beneficiario-lista',
    templateUrl: './Beneficiario-lista.component.html',
    styleUrls: ['./Beneficiario-lista.component.css']
})

export class BeneficiarioListaComponent {
  beneficiarioLista: IBeneficiarioDto[] = [];

  constructor(private http: HttpClient, private router: Router) {
    this.getBeneficiarios();
  }

  getBeneficiarios() {
    this.beneficiarioLista = [];
    this.http.get('https://localhost:7026/api/Beneficiario')
    .pipe(
      map((response: any) => {
        return Object.values(response);
      })
    )
    .subscribe((data) => {
      for(let index = 0; index < data.length; index++) {
        let json: any = data[index];
        this.beneficiarioLista.push(json as IBeneficiarioDto);
      }
    });
  }

  removerBeneficiario(id: number) {
    this.http.delete(`https://localhost:7026/api/Beneficiario/${id}`)
    .subscribe(() => {
      this.getBeneficiarios();
    });
  }
  
  editarBeneficiario(id: number) {
    this.router.navigate([`beneficiariocadastrar/${id}`]);
  }

  adicionarBeneficiario(){
    this.router.navigate([`beneficiariocadastrar`]);
  }
}