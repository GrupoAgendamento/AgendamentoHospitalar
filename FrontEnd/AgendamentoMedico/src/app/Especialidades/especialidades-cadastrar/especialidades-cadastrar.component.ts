import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { IEspecialidadeDto } from 'src/app/interfaces/IEspecialidadeDto';


  @Component({
  selector: 'app-especialidades-cadastrar',
  templateUrl: './especialidades-cadastrar.component.html',
  styleUrls: ['./especialidades-cadastrar.component.css']
  })

  export class EspecialidadesCadastrarComponent {
  especialidade!: IEspecialidadeDto;
  especialidadeLista : IEspecialidadeDto[] = [];

  ngOnInit(): void {
    this.especialidade = {
        idEspecialidade: 0,
        nome: '',
        descricao: '',
        ativo: true
      }

      this.getEspecialidades();
}

  constructor(private http: HttpClient, private router: Router) {
    this.getEspecialidades();
  }


  adicionarEspecialidade(){
    if(this.especialidade.idEspecialidade == 0){
    this.http.post('https://localhost:7026/api/Especialidade', this.especialidade)
    .subscribe(() => {
      this.router.navigate(['especialidadelista']);
      });
    }else {
      this.http.patch(`https://localhost:7026/api/Especialidade/${this.especialidade.idEspecialidade}`, this.especialidade)
      .subscribe(() => {
          this.router.navigate(['especialidadelista']);
      });
  }
  }

  editarEspecialidade(id: number){
    this.router.navigate([`especialidadecadastrar/${id}`]);

  }
  removerEspecialidade(id: number){
    this.http.delete(`https://localhost:7026/api/Especialidade/${id}`)
        .subscribe(() => {
            this.getEspecialidades();
        });

  }
  getEspecialidades(){
    this.especialidadeLista = [];
      this.http.get('https://localhost:7026/api/Especialidade')
      .pipe(
      map((response: any) => {
        return Object.values(response);
      })
    )
    .subscribe((data) => {
      for(let index = 0; index < data.length; index++) {
        let json: any = data[index];
        this.especialidadeLista.push(json as IEspecialidadeDto);
      }
    });
  }
}
