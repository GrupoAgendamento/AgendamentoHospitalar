import { HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Component } from '@angular/core';
import { IAgendamentoDto } from '../../interfaces/IAgendamentoDto';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editar-agendamento',
  templateUrl: './editar-agendamento.component.html',
  styleUrls: ['./editar-agendamento.component.css']
})
export class EditarAgendamentoComponent {
    agendamento!: IAgendamentoDto;
    profissionais: any = [];

    constructor(private http: HttpClient,
      private route: ActivatedRoute,
      private router: Router,
      private toastr: ToastrService
      ) {
        this.route.paramMap.subscribe((params) => {
          this.agendamento.idAgendamento = Number(params.get('id'));
        });

      }

  ngOnInit() {
    this.agendamento = {
      idAgendamento: 0,
      idHospital: 0,
      idEspecialidade: 0,
      idProfissional: 0,
      dataAgendamento: new Date(),
      cpf: '',
      numeroCarteirinha: '',
      hospital: '',
      especialidade: '',
      profissional: ''
    }

  }

  editarAgendamento() {
      this.http.put('https://localhost:7026/api/Agendamento/' + this.agendamento.idAgendamento, this.agendamento).subscribe(
      response => {this.router.navigate(['/Agendamento']); },
        error => console.log(error)
      );
      this.toastr.success('Agendamento salvo com sucesso.', 'Sucesso!', {
        timeOut: 3000,
      });
    }

}
