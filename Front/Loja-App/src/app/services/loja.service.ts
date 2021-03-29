import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Loja } from 'models/Loja';
import { Observable } from 'rxjs';

@Injectable()
export class LojaService {
baseurl = 'https://localhost:5001/api/loja';
constructor(private http: HttpClient) { }

  public getLoja(): Observable<Loja[]> {
    return this.http.get<Loja[]>(this.baseurl);
  }
  public getLojaByNomeFantasia(nomeFantasia: string): Observable<Loja[]> {
    return this.http.get<Loja[]>(`${this.baseurl}/${nomeFantasia}/temaFantasia`);
  }
  public getLojaById(id: number): Observable<Loja> {
    return this.http.get<Loja>(`${this.baseurl}/${id}`);
  }
  public postLoja(loja: Loja) {
    return this.http.post<Loja>(this.baseurl, loja);
  }
}
