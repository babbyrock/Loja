import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Loja } from 'models/Loja';
import { LojaService } from 'src/app/services/loja.service';



@Component({
  selector: 'app-loja-cadastrar',
  templateUrl: './loja-cadastrar.component.html',
  styleUrls: ['./loja-cadastrar.component.scss']
})
export class LojaCadastrarComponent implements OnInit {
  registerForm: FormGroup | any;
  loja: Loja | any;
  public lojas: Loja[] = [];
  public lojasFiltradas : Loja[] = [];

  constructor(
    private lojaService: LojaService
  ) { }

  ngOnInit(): void {
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
  validation(){
    this.registerForm = new FormGroup({
    nomeFantasia: new FormControl,
    cnpj: new FormControl,
    razaoSocial: new FormControl,
    telefone: new FormControl
    });
  }



  salvarAlteracao(template: TemplateRef<any>): void{
    if(this.registerForm.valid){
      this.loja = Object.assign({}, this.registerForm.value);
      this.lojaService.postLoja(this.loja).subscribe(
        (novaLoja: Loja) => {
          console.log(novaLoja);
          this.getLojas();
        }, error => {
          console.log(error);
        }
      )
    }

  }
}
