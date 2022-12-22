import { Component } from "@angular/core";
import { IProfissionalDto } from "src/app/interfaces/IProfissionalDto";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-profissional-lista',
    templateUrl: './profissional-lista.component.html',
    styleUrls: ['./profissional-lista.component.css']
})

export class ProfissionalListaComponent {
    profissionalLista: IProfissionalDto[] = [];
    profissionalFiltrados: any = [];
    private _filtroLista: string = "";

    public get filtroLista(){
        return this._filtroLista;
    }

    public set filtroLista(value: string){
        this._filtroLista = value;
        this.profissionalFiltrados = this.filtroLista ? this.filtrarProfissional(this.filtroLista) : this.profissionalLista;
    }

    filtrarProfissional(nome: string): any{
        return this.profissionalLista.filter(
            (profissional: { nome: string; }) => profissional.nome.toLowerCase().indexOf(nome.toLowerCase()) !== -1 ||
            profissional.nome.toLowerCase().indexOf(nome.toLowerCase()) !== -1
        );
    }

    constructor(private http: HttpClient, private router: Router, private toastr: ToastrService) {
        this.getProfissionais();
    }

    ngOnit() {
        this.getProfissionais();
    }

    getProfissionais() {
        this.profissionalLista = [];
        this.http.get('https://localhost:7026/api/Profissional')
        .subscribe(
            response => {this.profissionalLista = response as IProfissionalDto[]; this.profissionalFiltrados = this.profissionalLista; },
            error => console.log(error)
        );
    }

    removerProfissional(id: number) {
        this.http.delete(`https://localhost:7026/api/Profissional/${id}`)
        .subscribe(() => {
            this.toastr.success('Profissional excluído com sucesso.', 'Sucesso!', {
                timeOut: 3000
            })
            this.getProfissionais();
        });
    }

    editarProfissional(id: number) {
        this.router.navigate([`profissionaleditar/${id}`]);
    }

    adicionarProfissional(){
        this.router.navigate([`profissionalcadastrar`]);
    }
}
