import { Agendar } from './Agendar';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-agendar',
  templateUrl: './agendar.component.html',
  styleUrls: ['./agendar.component.css']
})
export class BeneficiarioCadastrarComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  agendar: Agendar = new Agendar();
  mensagem: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.agendar = new Agendar();
  }

  Salvar(){
    this.http.post('https://localhost:7088/api/Beneficiario', this.agendar).subscribe((response: any) => {
      this.agendar = new Agendar();
      this.mensagem = 'Agendamento cadastrado com sucesso!';
      setTimeout(() => {
        this.mensagem = '';
      }, 2000);
    }
    );
  }

}
