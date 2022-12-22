import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Component } from '@angular/core';
import { IAgendamentoDto } from '../../interfaces/IAgendamentoDto';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendar.component.html',
  styleUrls: ['./agendar.component.css']
})
export class AgendamentoCadastrarComponent {
    agendamento!: IAgendamentoDto;
    profissionais: any = [];
    especialidades: any = [];
    beneficiarios: any = [];
    hospitais: any = [];
    idHospitalSelecionado = 0;
    idBeneficiarioSelecionado = 0;
    idProfissionalSelecionado = 0;
    idEspecialidadeSelecionado = 0;
    dados = {
      hospital: this.idHospitalSelecionado,
      Beneficiario: this.idBeneficiarioSelecionado,
      Profissional: this.idProfissionalSelecionado,
      Especialidade: this.idEspecialidadeSelecionado
    }


    constructor(private http: HttpClient,
      private route: ActivatedRoute,
      private router: Router,
      private toastr: ToastrService
      ) {

      }

  ngOnInit() {

    this.agendamento = {
      idHospital: 0,
      idEspecialidade: 0,
      idProfissional: 0,
      DataHoraAgendamento: new Date(),
      idBeneficiario: 0,
      ativo: true,
      idBeneficiarioNavigation: {
        nome: '',
        cpf: '',
        telefone: '',
        endereco: '',
        numeroCarteirinha: '',
        ativo: true,
        email: '',
        senha: ''
      },
      idEspecialidadeNavigation: {
        idEspecialidade: 0,
        nome: '',
        descricao: '',
        ativo: true
      },
      idHospitalNavigation: {
        idHospital: 0,
        nome: '',
        cnpj: '',
        endereco: '',
        telefone: '',
        cnes: '',
        ativo: true
      },
      idProfissionalNavigation: {
        idProfissional: 0,
        nome: '',
        telefone: '',
        endereco: '',
        ativo: true
      }
    }

    this.getBeneficiario();
    this.getEspecialidade();
    this.getHospitais();
    this.getProfissional();
  }

  salvarAgendamento() {
    this.http.post('https://localhost:7026/api/Agendamento/AddPost', this.agendamento).subscribe((response: any) => {
      debugger;
      this.toastr.success('Agendamento realizado com sucesso!', 'Sucesso!');
      this.router.navigate(['/agendamento']);
    }, error => {
      this.toastr.error('Erro ao realizar agendamento!', 'Erro!');
      console.log(error);
    });
  }

  getHospitais() {
    this.http.get('https://localhost:7026/api/Hospital').subscribe((response: any) => {
      this.hospitais = response;
    }, error => {
      console.log(error);
    });
  }

  getEspecialidade() {
    this.http.get('https://localhost:7026/api/Especialidade').subscribe((response: any) => {
      this.especialidades = response;
    }, error => {
      console.log(error);
    });
  }

  getProfissional() {
    this.http.get('https://localhost:7026/api/Profissional').subscribe((response: any) => {
      this.profissionais = response;
    }, error => {
      console.log(error);
    });
  }

  getBeneficiario() {
    this.http.get('https://localhost:7026/api/Beneficiario').subscribe((response: any) => {
      this.beneficiarios = response;
    }, error => {
      console.log(error);
    });
  }

  onSelect(){
    this.dados = {
      hospital: this.idHospitalSelecionado,
      Beneficiario: this.idBeneficiarioSelecionado,
      Profissional: this.idProfissionalSelecionado,
      Especialidade: this.idEspecialidadeSelecionado
    }
  }

  onChange() {
    console.log(this.idBeneficiarioSelecionado);
  }
}
