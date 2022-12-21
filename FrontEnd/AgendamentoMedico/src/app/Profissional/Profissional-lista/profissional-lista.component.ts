import { Component } from "@angular/core";
import { IProfissionalDto } from "src/app/interfaces/IProfissionalDto";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-profissional-lista',
    templateUrl: './profissional-lista.component.html',
    styleUrls: ['./profissional-lista.component.css']
})

export class ProfissionalListaComponent {
    profissionalLista: IProfissionalDto[] = [];

    constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) {
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

    removerProfissional(id: number) {
        this.http.delete(`https://localhost:7026/api/Profissional/${id}`)
        .subscribe(() => {
            confirm(`Deseja realmente excluir o hospital?`);
            this.toastr.success('Hospital exclúido com sucesso.', 'Sucesso!', {
                timeOut: 3000
            })
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
