import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-Beneficiario-Editar',
  templateUrl: './Beneficiario-Editar.component.html',
  styleUrls: ['./Beneficiario-Editar.component.css']
})
export class BeneficiarioEditarComponent implements OnInit {

  beneficiario!: any;
  idBeneficiario!: number;

  constructor(private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
    ) {
      this.route.paramMap.subscribe((params) => {
        this.idBeneficiario = Number(params.get('id'));
     });

    }

  ngOnInit() {
    this.getBeneficiarioById(this.idBeneficiario);
    this.beneficiario = {
      nome: '',
      cpf: '',
      telefone: '',
      email: '',
      endereco: '',
      numeroCarteirinha: '',
      ativo: false,
      senha: '',
    }
  }

  public getBeneficiarioById(id: number){
    this.http.get('https://localhost:7026/api/Beneficiario/' + id).subscribe(
      response => {this.beneficiario = response; },
      error => console.log(error)
    );
  }

  public editarBeneficiario(){
    this.http.put('https://localhost:7026/api/Beneficiario/' + this.idBeneficiario, this.beneficiario).subscribe(
      response => {this.router.navigate(['/beneficiariolista']); },
      error => console.log(error)
    );
  }

}