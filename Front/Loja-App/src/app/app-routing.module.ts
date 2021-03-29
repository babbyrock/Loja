import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FuncionarioComponent } from './components/funcionario/funcionario.component';
import { LojaComponent } from './components/loja/loja.component';
import { LojaCadastrarComponent } from './components/lojas/loja-cadastrar/loja-cadastrar.component';
import { LojaListaComponent } from './components/lojas/loja-lista/loja-lista.component';

const routes: Routes = [
  { path: 'lojas', component: LojaComponent,
    children:[
      { path : 'cadastrar/:id' , component:LojaCadastrarComponent},
      { path : 'cadastrar' , component:LojaCadastrarComponent}
    ]
    },
  { path: 'funcionarios', component: FuncionarioComponent},
  { path: 'loja', component: LojaListaComponent},
  { path: '', redirectTo: 'loja', pathMatch: 'full' },
  { path: 'loja/lojas/cadastrar', redirectTo: 'lojas/cadastrar', pathMatch: 'full' }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
