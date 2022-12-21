import { Component, OnInit } from '@angular/core';
import { IBeneficiarioDto } from 'src/app/interfaces/IBeneficiarioDto';
import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-beneficiario-editar',
  templateUrl: './Beneficiario-editar.component.html',
  styleUrls: ['./Beneficiario-editar.component.css'],
})
export class BeneficiarioEditarComponent implements OnInit {
  beneficiario!: any;
  idBeneficiario!: number;
  constructor(
    private http: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {
    this.route.paramMap.subscribe((params) => {
      this.idBeneficiario = Number(params.get('id'));
   });
  }

  ngOnInit(): void {
    this.getBeneficiarioById(this.idBeneficiario);
    this.beneficiario = {
      nome: '',
      cpf: '',
      telefone: '',
      email: '',
      endereco: '',
      numeroCarteirinha: '',
      senha: '',
      ativo: false,
    };
  }

  public getBeneficiarioById(id: number){
    this.http.get('https://localhost:7026/api/Beneficiario/' + id).subscribe(
      response => {this.beneficiario = response; },
      error => console.log(error)
    );
  }

  editarBeneficiario() {
    if (this.validarInfo()) {
      if (this.idBeneficiario == 0) {
        this.http
          .post('https://localhost:7026/api/Beneficiario', this.beneficiario)
          .subscribe(() => {
            this.router.navigate(['beneficiariolista']);
            this.toastr.success(
              'Beneficiário cadastrado com sucesso.',
              'Sucesso!',
              {
                timeOut: 3000,
              }
            );
          });
      } else {
        this.http
          .patch(
            `https://localhost:7026/api/Beneficiario/${this.idBeneficiario}`,
            this.beneficiario
          )
          .subscribe(() => {
            this.router.navigate(['beneficiariolista']);
          });
      }
    } else {
      this.toastr.warning(
        'Preencha todos os campos!',
        'Campos vazios',
        {
          timeOut: 3000,
        }
      );
    }
  }

  validarInfo(): boolean {
    if (
      this.beneficiario.nome == '' ||
      this.beneficiario.cpf == '' ||
      this.beneficiario.numeroCarteirinha == '' ||
      this.beneficiario.email == '' ||
      this.beneficiario.senha == ''
    ) {
      return false;
    }
    return true;
  }
}
