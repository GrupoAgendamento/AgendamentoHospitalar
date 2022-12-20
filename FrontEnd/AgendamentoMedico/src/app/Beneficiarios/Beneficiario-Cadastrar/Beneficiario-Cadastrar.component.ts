import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Beneficiario } from './Beneficiario';

@Component({
  selector: 'app-Beneficiario-Cadastrar',
  templateUrl: './Beneficiario-Cadastrar.component.html',
  styleUrls: ['./Beneficiario-Cadastrar.component.css']
})
export class BeneficiarioCadastrarComponent implements OnInit {

  form: FormGroup = new FormGroup({});
  beneficiario: Beneficiario = new Beneficiario();
  mensagem: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.beneficiario = new Beneficiario();
  }

  Salvar(){
    this.http.post('https://localhost:7088/api/Beneficiario', this.beneficiario).subscribe((response: any) => {
      this.beneficiario = new Beneficiario();
      this.mensagem = 'Beneficiário cadastrado com sucesso!';
      setTimeout(() => {
        this.mensagem = '';
      }, 2000);
    }
    );
  }

}
