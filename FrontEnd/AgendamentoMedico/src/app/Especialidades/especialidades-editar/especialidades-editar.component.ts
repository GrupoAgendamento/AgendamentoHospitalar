import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IEspecialidadeDto } from 'src/app/interfaces/IEspecialidadeDto';


@Component({
  selector: 'app-especialidades-editar',
  templateUrl: './especialidades-editar.component.html',
  styleUrls: ['./especialidades-editar.component.css']
})
export class EspecialidadesEditarComponent implements OnInit {
  especialidade!: any;
  idEspecialidade!: number;
  ngOnInit(): void {

    this.especialidade = {
      idEspecialidade: 0,
      nome: '',
      descricao: '',
      ativo: true
    }
    this.getEspecialidadeById(this.idEspecialidade);
  }


  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private toastr: ToastrService){
    this.route.paramMap.subscribe((params) => {
      this.idEspecialidade = Number(params.get('id'));
  });
  }


  editarEspecialidade(){
    this.http
      .put('https://localhost:7026/api/Especialidade/' + this.idEspecialidade, this.especialidade)
      .subscribe(
        (response) => {
          this.router.navigate(['/especialidadecadastrar/'+ this.idEspecialidade]);
          this.toastr.success('Especialidade editada com sucesso!');
        },
        (error) => {
          this.toastr.error('Erro ao editar especialidade!');
          console.log(error);
        }
      );

   }
   getEspecialidadeById(id: number){
    this.http.get('https://localhost:7026/api/Especialidade/' + id).subscribe(
      response => {this.especialidade = response; },
      error => console.log(error)
    );
  }

    salvarEspecialidade(){
      this.http.put(`https://localhost:7026/api/Especialidade/${this.especialidade.idEspecialidade}`, this.especialidade)
      .subscribe(() => {
        this.router.navigate(['especialidadescadastrar']);
        });
      }
    }




