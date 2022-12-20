import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Beneficiario-Lista',
  templateUrl: './Beneficiario-Lista.component.html',
  styleUrls: ['./Beneficiario-Lista.component.css']
})
export class BeneficiarioListaComponent implements OnInit {

  public beneficiarios: any = [];
  frase: string = "";

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getBeneficiarios();
  }

  public getBeneficiarios(){
    this.http.get('https://localhost:7026/api/Beneficiario').subscribe(
      response => {this.beneficiarios = response; },
      error => console.log(error)
    );
  }


}
