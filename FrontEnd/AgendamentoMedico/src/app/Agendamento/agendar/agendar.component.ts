import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IAgendamentoDto } from '../../interfaces/IAgendamentoDto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-agendar',
  templateUrl: './agendar.component.html',
  styleUrls: ['./agendar.component.css']
})
export class AgendamentoCadastrarComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  agendamento!: IAgendamentoDto;
  mensagem: string = '';

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.agendamento = {
      idAgendamento: 0,
      idHospital: 0,
      idEspecialidade: 0,
      idProfissional: 0,
      dataAgendamento: new Date(),
      cpf: '',
      numeroCarteirinha: '',
    }
  }

  Salvar(){
    if(this.agendamento.idAgendamento == 0){
      this.http.post('https://localhost:7026/api/Agendamento', this.agendamento)    .subscribe(() =>
      {this.router.navigate(['consultar']);});
      }
      else
      {
        this.http.patch(`https://localhost:7026/api/Agendamento/${this.agendamento.idAgendamento}`, this.agendamento)      .subscribe(() =>
        {
          this.router.navigate(['consultar']);      });  }  }
  }
