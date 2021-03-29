import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LojaComponent } from './components/loja/loja.component';
import { FuncionarioComponent } from './components/funcionario/funcionario.component';
import { NavComponent } from './shared/nav/nav.component';
import { TituloComponent } from './shared/titulo/titulo.component';

import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { CollapseModule } from 'ngx-bootstrap/collapse';

import { LojaService } from './services/loja.service';
import { LojaCadastrarComponent } from './components/lojas/loja-cadastrar/loja-cadastrar.component';
import { LojaListaComponent } from './components/lojas/loja-lista/loja-lista.component';


@NgModule({
  declarations: [
    AppComponent,
    LojaComponent,
    FuncionarioComponent,
    NavComponent,
    TituloComponent,
    LojaCadastrarComponent,
    LojaListaComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }

    )
  ],
  providers: [LojaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
