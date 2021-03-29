import { Component, OnInit, TemplateRef} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Loja } from 'models/Loja';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { LojaService } from 'src/app/services/loja.service';

@Component({
  selector: 'app-loja-lista',
  templateUrl: './loja-lista.component.html',
  styleUrls: ['./loja-lista.component.scss']
})
export class LojaListaComponent implements OnInit {
  modalRef: BsModalRef | any;


  public lojas: Loja[] = [];
  public lojasFiltradas : Loja[] = [];
  private _filtroLista: string = '';



  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.lojasFiltradas = this.filtroLista ? this.filtrarLojas(this.filtroLista) : this.lojas;
  }

  public filtrarLojas(filtrarPor:string): Loja[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.lojas.filter(
      (loja : any) => loja.nomeFantasia.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      loja.cnpj.toLocaleLowerCase().indexOf(filtrarPor)!== -1 ||
      loja.razaoSocial.toLocaleLowerCase().indexOf(filtrarPor)!== -1

      );

  }

  constructor(
    private lojaService: LojaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private router: Router
    ) { }

  public ngOnInit(): void {
    this.getLojas();
  }

  public getLojas(): void{
    this.lojaService.getLoja().subscribe({
      next: (_lojas: Loja[]) => {
        this.lojas = _lojas;
        this.lojasFiltradas = this.lojas;
      },
      error: (error: any) => console.log(error)
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef.hide();
    this.toastr.success('A Loja foi deletada com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef.hide();
  }

  cadastrarLoja(id: number): void{
    this.router.navigate([`lojas/cadastrar/${id}`]);
  }


}
