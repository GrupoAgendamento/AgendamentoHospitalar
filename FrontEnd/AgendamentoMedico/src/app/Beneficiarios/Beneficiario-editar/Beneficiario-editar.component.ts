import { Component, OnInit } from '@angular/core';
import { IBeneficiarioDto } from 'src/app/interfaces/IBeneficiarioDto';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-beneficiario-editar',
  templateUrl: './Beneficiario-editar.component.html',
  styleUrls: ['./Beneficiario-editar.component.css'],
})
export class BeneficiarioEditarComponent implements OnInit {
  beneficiario!: IBeneficiarioDto;

  constructor(
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.beneficiario = {
      idBeneficiario: 0,
      nome: '',
      cpf: '',
      telefone: '',
      email: '',
      endereco: '',
      numeroCarteirinha: '',
      senha: '',
    };
  }

  salvarBeneficiario() {
    if (this.validarInfo()) {
      if (this.beneficiario.idBeneficiario == 0) {
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
            `https://localhost:7026/api/Beneficiario/${this.beneficiario.idBeneficiario}`,
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
