import { Component } from "@angular/core";
import { IHospitalDto } from "src/app/interfaces/IHospitalDto";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs';

@Component({
    selector: 'app-hospital-lista',
    templateUrl: './hospital-lista.component.html',
    styleUrls: ['./hospital-lista.component.css']
})

export class HospitalListaComponent {
    hospitalLista: IHospitalDto[] = [];

    constructor(private http: HttpClient, private router: Router) {
        this.getHospitais();
    }

    getHospitais() {
        this.hospitalLista = [];
        this.http.get('https://localhost:7026/api/Hospital')
        .pipe(
            map((response: any) => {
                return Object.values(response);
            })
        )
        .subscribe((data) => {
            for(let index = 0; index < data.length; index++) {
                let json: any = data[index];
                this.hospitalLista.push(json as IHospitalDto);
            }
        });
    }

    detalharHospital(id: number) {
        for(let i = 0; i < this.hospitalLista.length; i++) {
          if(id == this.hospitalLista[i].idHospital) {
            this.router.navigate([`hospitaldetalhe/${id}`]);
            break;
          }
        }
    }

    removerHospital(id: number) {
        this.http.delete(`https://localhost:7026/api/Hospital/${id}`)
        .subscribe(() => {
            this.getHospitais();
        });
    }

    editarHospital(id: number) {
        this.router.navigate([`hospitalcadastrar/${id}`]);
    }

    adicionarHospital(){
        this.router.navigate([`hospitalcadastrar`]);
    }
}
