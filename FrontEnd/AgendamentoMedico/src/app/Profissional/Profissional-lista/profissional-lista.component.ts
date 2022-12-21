import { Component } from "@angular/core";
import { IProfissionalDto } from "src/app/interfaces/IProfissionalDto";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs';

@Component({
    selector: 'app-profissional-lista',
    templateUrl: './profissional-lista.component.html',
    styleUrls: ['./profissional-lista.component.css']
})

export class ProfissionalListaComponent {
    profissionalLista: IProfissionalDto[] = [];

    constructor(private http: HttpClient, private router: Router) {
        this.getProfissionais();
    }

    getProfissionais() {
        this.profissionalLista = [];
        this.http.get('https://localhost:7026/api/Profissional')
        .pipe(
            map((response: any) => {
                return Object.values(response);
            })
        )
        .subscribe((data) => {
            for(let index = 0; index < data.length; index++) {
                let json: any = data[index];
                this.profissionalLista.push(json as IProfissionalDto);
            }
        });
    }

    detalharProfissional(id: number) {
        for(let i = 0; i < this.profissionalLista.length; i++) {
          if(id == this.profissionalLista[i].idProfissional) {
            this.router.navigate([`profissionaldetalhe/${id}`]);
            break;
          }
        }
    }

    removerProfissional(id: number) {
        this.http.delete(`https://localhost:7026/api/Profissional/${id}`)
        .subscribe(() => {
            this.getProfissionais();
        });
    }

    editarProfissional(id: number) {
        this.router.navigate([`profissionalcadastrar/${id}`]);
    }

    adicionarProfissional(){
        this.router.navigate([`profissionalcadastrar`]);
    }
}
