import { IProfissionalDto } from '../../interfaces/IProfissionalDto';
import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-profissional-editar',
    templateUrl: './profissional-editar.component.html',
    styleUrls: ['./profissional-editar.component.css']
})

export class ProfissionalEditarComponent implements OnInit {
    profissional!: any;
    idProfissional!: number;

    constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router, private toastr: ToastrService) {
      this.route.paramMap.subscribe((params) => {
        this.idProfissional = Number(params.get('id'));
     });

    }

    ngOnInit() {
      this.getProfissionalById(this.idProfissional);
      this.profissional = {
            idProfissional: 0,
            nome: '',
            endereco: '',
            telefone: '',
            ativo: true
          }
    }

    public getProfissionalById(id: number){
      this.http.get('https://localhost:7026/api/Profissional/' + id).subscribe(
        response => {this.profissional = response; },
        error => console.log(error)
      );
    }

    public editarProfissional(){
      this.http.put('https://localhost:7026/api/Profissional/' + this.idProfissional, this.profissional).subscribe(
      response => {this.router.navigate(['/profissionallista']); },
        error => console.log(error)
      );
      this.toastr.success('Hospital salvo com sucesso.', 'Sucesso!', {
        timeOut: 3000,
      });
    }

  }
