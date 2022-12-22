import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-beneficiario-lista',
  templateUrl: './Beneficiario-lista.component.html',
  styleUrls: ['./Beneficiario-lista.component.css'],
})
export class BeneficiarioListaComponent implements OnInit {
  public beneficiarios: any = [];
  public beneficiariosFiltrados: any = [];
  frase: string = '';
  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value.replace('.', '');
    this.beneficiariosFiltrados = this.filtroLista
      ? this.filtrarBeneficiarios(this.filtroLista)
      : this.beneficiarios;
  }

  filtrarBeneficiarios(filtrarPor: string): any {
    filtrarPor = filtrarPor.replace('.', '');
    return this.beneficiarios.filter(
      (beneficiario: { cpf: string }) =>
        beneficiario.cpf.replace('.', '').indexOf(filtrarPor) !== -1 ||
        beneficiario.cpf.toLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) {}

  ngOnInit() {
    this.getBeneficiarios();
  }

  public getBeneficiarios() {
    this.http.get('https://localhost:7026/api/Beneficiario').subscribe(
      (response) => {
        this.beneficiarios = response;
        this.beneficiariosFiltrados = this.beneficiarios;
      },
      (error) => console.log(error)
    );
  }

  public excluirBeneficiario(id: number) {
    this.http.delete('https://localhost:7026/api/Beneficiario/' + id).subscribe(
      (response) => {
        this.getBeneficiarios();
      },
      (error) => console.log(error)
    );
    confirm(`Deseja realmente excluir o beneficiário?`);
    this.toastr.success('Beneficiário excluído com sucesso.', 'Sucesso!', {
      timeOut: 3000,
    });
  }

  editarBeneficiario(id: number) {
    this.router.navigate([`beneficiarioeditar/${id}`]);
  }

  adicionarProfissional(){
    this.router.navigate([`beneficiariocadastrar`]);
}
}
