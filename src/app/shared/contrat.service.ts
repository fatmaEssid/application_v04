import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Contrat } from './contrat.model';


@Injectable({
  providedIn: 'root'
})
export class ContratService {
  formData: Contrat;
  constructor(private http: HttpClient) { }
  getContratList() {
   return this.http.get(environment.apiURL+'/Contrat').toPromise();
  }
  
  saveOrUpdateContrat(){
    return this.http.post(environment.apiURL+'/Contrat', this.formData);
 }
}
