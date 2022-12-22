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

    constructor(private http: HttpClient,
      private route: ActivatedRoute,
      private router: Router,
      private toastr: ToastrService
      ) {

      }

  ngOnInit() {
    this.agendamento = {
      idAgendamento: 0,
      idHospital: 0,
      idEspecialidade: 0,
      idProfissional: 0,
      dataAgendamento: new Date(),
      beneficiario: '',
      idBeneficiario: 0,
      numeroCarteirinha: '',
      hospital: '',
      especialidade: '',
      profissional: ''
    }

    this.getBeneficiario();
    this.getEspecialidade();
    this.getHospitais();
    this.getProfissional();
  }

  salvarAgendamento(){
    if(this.agendamento.idAgendamento == 0){
      this.http.post('https://localhost:7026/api/Agendamento', this.agendamento)    .subscribe(() =>
      {this.router.navigate(['agendamentoconsultar']);});
      }
      else
      {
        this.http.patch(`https://localhost:7026/api/Agendamento/${this.agendamento.idAgendamento}`, this.agendamento)      .subscribe(() =>
        {
          this.router.navigate(['agendamentoconsultar']);      });  }  }

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
  }
