import { Component, OnInit } from "@angular/core";
import { IHospitalDto } from "src/app/interfaces/IHospitalDto";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-hospital-editar',
    templateUrl: './hospital-editar.component.html',
    styleUrls: ['./hospital-editar.component.css']
})

export class HospitalEditarComponent implements OnInit {
    hospital!: IHospitalDto

    constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router, private toastr: ToastrService) {
        this.route.component
    }

    ngOnInit(): void {
        this.hospital = {
            id: 0,
            nome: '',
            cnpj: '',
            endereco: '',
            telefone: '',
            cnes: '',
            ativo: true
          }
    }

    salvarHospital() {
        if(this.validarInfo()) {
            this.http.post('https://localhost:7026/api/Hospital', this.hospital)
            .subscribe(() => {
                this.router.navigate(['hospitallista']);
                this.toastr.success('Hospital cadastrado com sucesso.', 'Sucesso!', {
                    timeOut: 3000
                })
              });
        } else {
            this.toastr.warning('Preencha o campo: Nome do hospital.', 'Campo vazio', {
                timeOut: 3000,
            });
        }
    }

    validarInfo(): boolean {
        if (this.hospital.nome == '') {
          return false;
        }
        return true;
      }

}