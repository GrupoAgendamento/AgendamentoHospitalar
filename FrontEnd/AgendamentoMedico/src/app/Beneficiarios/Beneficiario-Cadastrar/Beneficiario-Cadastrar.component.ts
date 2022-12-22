import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr/toastr/toastr.service';
import { IBeneficiarioDTO } from '../../interfaces/IBeneficiarioDTO';

@Component({
  selector: 'app-Beneficiario-Cadastrar',
  templateUrl: './Beneficiario-Cadastrar.component.html',
  styleUrls: ['./Beneficiario-Cadastrar.component.css']
})
export class BeneficiarioCadastrarComponent implements OnInit {
  form: FormGroup = new FormGroup({});
  beneficiario!: IBeneficiarioDTO;
  mensagem: string = '';

  constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) { }

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
      this.toastr.success('Beneficiário cadastrado com sucesso.', 'Sucesso!', {
        timeOut: 3000
      })
    }
    );
  }

}
