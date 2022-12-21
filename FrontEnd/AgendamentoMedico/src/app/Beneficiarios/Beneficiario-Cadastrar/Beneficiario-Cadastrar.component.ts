import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IBeneficiarioDto } from '../../interfaces/IBeneficiarioDto';

@Component({
  selector: 'app-Beneficiario-Cadastrar',
  templateUrl: './Beneficiario-Cadastrar.component.html',
  styleUrls: ['./Beneficiario-Cadastrar.component.css']
})
export class BeneficiarioCadastrarComponent implements OnInit {

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
      this.beneficiario = { nome: '', cpf: '', telefone: '', email: '', endereco: '', numeroCarteirinha: '', ativo: false, senha: ''}
      this.mensagem = 'Beneficiário cadastrado com sucesso!';
      setTimeout(() => {
        this.mensagem = '';
      }, 2000);
    }
    );
  }

}
