import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Company } from '../@types/Company';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private httpClient: HttpClient) { }

  getCompanies(): Observable<Company[]> {
    return this.httpClient.get<Company[]>(`${environment.apiUrl}/companies`);
  }

}
