import { Agendar } from './Agendar';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IBeneficiarioDto } from 'src/app/interfaces/IBeneficiarioDto';
@Component({
  selector: 'app-agendar',
  templateUrl: './agendar.component.html',
  styleUrls: ['./agendar.component.css']
})
export class AgendarComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  beneficiario!: IBeneficiarioDto;
  mensagem: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.beneficiario = {
      nome: '',
      cpf: '',
      telefone: '',
      email: '',
      endereco: '',
      numeroCarteirinha: '',
      ativo: false,
      senha: '',
    }
  }

  Salvar(){
    this.http.post('https://localhost:7026/api/Beneficiario', this.beneficiario).subscribe((response: any) => {
      this.mensagem = 'Beneficiário cadastrado com sucesso!';
      setTimeout(() => {
        this.mensagem = '';
      }, 2000);
    }
    );
  }

}
