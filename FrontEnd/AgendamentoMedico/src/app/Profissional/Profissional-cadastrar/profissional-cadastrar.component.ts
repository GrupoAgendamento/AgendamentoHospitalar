import { IProfissionalDto } from '../../interfaces/IProfissionalDto';
import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
@Component({
    selector: 'app-profissional-cadastrar',
    templateUrl: './profissional-cadastrar.component.html',
    styleUrls: ['./profissional-cadastrar.component.css']
})
export class ProfissionalCadastrarComponent implements OnInit {
    profissional!: IProfissionalDto
    constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) {
    }
    ngOnInit(): void {
        this.profissional = {
            idProfissional: 0,
            nome: '',
            endereco: '',
            telefone: '',
            ativo: true
          }
    }
    salvarProfissional() {
        if(this.validarInfo()) {
            if(this.profissional.idProfissional == 0) {
                this.http.post('https://localhost:7026/api/Profissional', this.profissional)
                .subscribe(() => {
                    this.router.navigate(['profissionallista']);
                    this.toastr.success('Profissional cadastrado com sucesso.', 'Sucesso!', {
                        timeOut: 3000
                    })
                });
            } else {
                this.http.patch(`https://localhost:7026/api/Profissional/${this.profissional.idProfissional}`, this.profissional)
                .subscribe(() => {
                    this.router.navigate(['profissionallista']);
                });
            }
        } else {
            this.toastr.warning('Preencha o campo: Nome do profissional.', 'Campo vazio', {
                timeOut: 3000,
            });
        }
    }
    validarInfo(): boolean {
        if (this.profissional.nome == '') {
          return false;
        }
        return true;
      }
}