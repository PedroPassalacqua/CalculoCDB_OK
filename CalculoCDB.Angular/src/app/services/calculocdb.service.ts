import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { calculo } from '../app.component';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class CalculocdbService {

  constructor(private http: HttpClient) { }
    
  getcalculocdb(valor_inicial:any, num_meses:any):Observable<calculo[]> {
    return this.http.get<calculo[]>('https://localhost:7071/api/CalculoCdb?valor_inicial='+valor_inicial+'&num_meses='+num_meses);
  } 
}


