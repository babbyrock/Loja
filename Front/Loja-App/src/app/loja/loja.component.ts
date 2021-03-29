import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.scss']
})
export class LojaComponent implements OnInit {

  public lojas: any = [];
  public lojasFiltradas : any = [];
  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.lojasFiltradas = this.filtroLista ? this.filtrarLojas(this.filtroLista) : this.lojas;
  }

  filtrarLojas(filtrarPor:string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.lojas.filter(
      (loja : any) => loja.nomeFantasia.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      loja.cnpj.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      loja.razaoSocial.toLocaleLowerCase().indexOf(filtrarPor)!== -1

      )

  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void{

    this.http.get('https://localhost:5001/api/loja').subscribe(
      response => {
        this.lojas = response;
        this.lojasFiltradas = this.lojas;
      },
      error => console.log(error)
    );
  }
}
