import { Component } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { IAgendamentoDto } from 'src/app/interfaces/IAgendamentoDto';

@Component({
    selector: 'app-consultar',
    templateUrl: './consultar.component.html',
    styleUrls: ['./consultar.component.css']
})

export class ConsultarComponent {
    agendamentoLista: IAgendamentoDto[] = [];

    constructor(private http: HttpClient, private router: Router) {
        this.getAgendamentos();
    }

    getAgendamentos() {
        this.agendamentoLista = [];
        this.http.get('https://localhost:7026/api/Agendamento')
        .pipe(
            map((response: any) => {
                return Object.values(response);
            })
        )
        .subscribe((data) => {
            for(let index = 0; index < data.length; index++) {
                let json: any = data[index];
                this.agendamentoLista.push(json as IAgendamentoDto);
            }
        });
    }

    removerAgendamento(id: number) {
        this.http.delete(`https://localhost:7026/api/Agendamento/${id}`)
        .subscribe(() => {
            this.getAgendamentos();
        });
    }

    editarAgendamento(id: number) {
        this.router.navigate([`agendamento/${id}`]);
    }

    adicionarAgendamento(){
        this.router.navigate([`agendamento`]);
    }
}
