import { Component } from '@angular/core';
import { IHospitalDto } from 'src/app/interfaces/IHospitalDto';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-hospital-lista',
  templateUrl: './hospital-lista.component.html',
  styleUrls: ['./hospital-lista.component.css'],
})
export class HospitalListaComponent {
  hospitalLista: IHospitalDto[] = [];
  hospitalFiltrados: any = [];
  private _filtroLista: string = '';

  public get filtroLista() {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.hospitalFiltrados = this.filtroLista
      ? this.filtrarHospital(this.filtroLista)
      : this.hospitalLista;
  }

  filtrarHospital(nome: string): any {
    return this.hospitalLista.filter(
      (hospital: { nome: string }) =>
        hospital.nome.toLowerCase().indexOf(nome.toLowerCase()) !== -1 ||
        hospital.nome.toLowerCase().indexOf(nome.toLowerCase()) !== -1
    );
  }

  ngOnit() {
    this.getHospitais();
  }

  constructor(
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.getHospitais();
  }

  getHospitais() {
    this.hospitalLista = [];
    this.http.get('https://localhost:7026/api/Hospital').subscribe(
      (response) => {
        this.hospitalLista = response as IHospitalDto[];
        this.hospitalFiltrados = this.hospitalLista;
      },
      (error) => console.log(error)
    );
  }

  removerHospital(id: number) {
    this.http
      .delete(`https://localhost:7026/api/Hospital/${id}`)
      .subscribe(() => {
        this.toastr.success('Hospital excluído com sucesso.', 'Sucesso!', {
          timeOut: 3000,
        });
        this.getHospitais();
      });
  }

  editarHospital(id: number) {
    this.router.navigate([`hospitaleditar/${id}`]);
  }

  adicionarHospital() {
    this.router.navigate([`hospitalcadastrar`]);
  }
}
