import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-hospital-editar',
  templateUrl: './hospital-editar.component.html',
  styleUrls: ['./hospital-editar.component.css']
})
export class HospitalEditarComponent implements OnInit {

  hospital!: any;
  idHospital!: number;

  constructor(private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
    ) {
      this.route.paramMap.subscribe((params) => {
        this.idHospital = Number(params.get('id'));
     });

    }

  ngOnInit() {
    this.getHospitalById(this.idHospital);
    this.hospital = {
      nome: '',
      cnpj: '',
      endereco: '',
      telefone: '',
      cnes: '',
      ativo: false
    }
  }

  public getHospitalById(id: number){
    this.http.get('https://localhost:7026/api/Hospital/' + id).subscribe(
      response => {this.hospital = response; },
      error => console.log(error)
    );
  }

  public editarHospital(){
    this.http.put('https://localhost:7026/api/Hospital/' + this.idHospital, this.hospital).subscribe(
    response => {this.router.navigate(['/hospitallista']); },
      error => console.log(error)
    );
    this.toastr.success('Hospital salvo com sucesso.', 'Sucesso!', {
      timeOut: 3000,
    });
  }

}
