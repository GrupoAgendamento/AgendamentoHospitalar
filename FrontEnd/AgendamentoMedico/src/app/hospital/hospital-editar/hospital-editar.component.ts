import { Component } from "@angular/core";
import { IHospitalDto } from "src/app/interfaces/IHospitalDto";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: 'app-hospital-editar',
    templateUrl: './hospital-editar.component.html',
    styleUrls: ['./hospital-editar.component.css']
})

export class HospitalEditarComponent {
    hospital!: IHospitalDto

    constructor(private http: HttpClient, private route: ActivatedRoute) {
        this.route.component
    }

    salvarHospital() {
        this.http.get('https://localhost:7088/ListarTodos')
    }

}