import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IEspecialidadeDto } from 'src/app/interfaces/IEspecialidadeDto';
import { ToastrService } from 'ngx-toastr';


  @Component({
  selector: 'app-especialidades-cadastrar',
  templateUrl: './especialidades-cadastrar.component.html',
  styleUrls: ['./especialidades-cadastrar.component.css']
  })

  export class EspecialidadesCadastrarComponent {
  idEspecialidade!: number;
  especialidade!: IEspecialidadeDto;
  especialidadeLista : IEspecialidadeDto[] = [];
  especialidadeFiltrados: any = [];
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.especialidadeFiltrados = this.filtroLista ? this.filtrarEspecialidade(this.filtroLista) : this.especialidadeLista;
  }

  ngOnInit(): void {
    this.especialidade = {
      idEspecialidade: 0,
      nome: '',
      descricao: '',
      ativo: true
    }
    this.getEspecialidades();
    this.getEspecialidadeById(this.idEspecialidade);
  }

  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private toastr: ToastrService)
  {
    this.route.paramMap.subscribe((params) => {
      this.idEspecialidade = Number(params.get('id'));
  });
  }

      adicionarEspecialidade(){
        if(this.validarInfo()) {
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
        }else {
          this.toastr.warning('Preencha o campo: Nome da especialidade.', 'Campo vazio', {
            timeOut: 3000,
        });
      }
    }

  filtrarEspecialidade(nome: string): any{
      return this.especialidadeLista.filter(
      (especialidade: {nome: string; }) => especialidade.nome.toLowerCase().indexOf(nome.toLowerCase()) !== -1 ||
      especialidade.nome.toLowerCase().indexOf(nome) !== -1
    );
  }

  editarEspecialidade(){
    if (this.validarInfo()) {
      this.http
        .put('https://localhost:7026/api/Especialidade/' + this.idEspecialidade, this.especialidade)
        .subscribe(
          (response) => {
            this.toastr.success('Especialidade editada com sucesso!');
            this.router.navigate(['/especialidadelista']);
          },
          (error) => {
            this.toastr.error('Erro ao editar especialidade!');
            console.log(error);
          }
        );
    } else {
      this.toastr.error('Preencha todos os campos!');
    }
  }




  getEspecialidadeById(id: number){
    this.http.get('https://localhost:7026/api/Especialidade/' + id).subscribe(
      response => {this.especialidade = response as IEspecialidadeDto; },
      error => console.log(error)
    );
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
      .subscribe(
        response => {this.especialidadeLista = response as IEspecialidadeDto[]; this.especialidadeFiltrados = this.especialidadeLista; },
        error => console.log(error)
    );
  }

  validarInfo(): boolean {
    if (this.especialidade.nome == '') {
      return false;
    }
      return true

  }
}
