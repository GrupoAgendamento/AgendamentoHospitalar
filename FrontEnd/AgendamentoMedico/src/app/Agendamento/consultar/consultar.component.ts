import { Consultar } from './Consultar';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-agendar',
  templateUrl: './consultar.component.html',
  styleUrls: ['./consultar.component.css']
})
export class ConsultarComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  consultar: Consultar = new Consultar();
  mensagem: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.consultar = new Consultar();
  }

  allConsultas: Consultar[] = [];
  //consulta = Consultar[] = [];
  baseApiUrl = 'https://localhost:7026/api/Agendamento';

  Mostrar(){

  }

}
