import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Contract } from '../@types/Contract';

@Injectable({
  providedIn: 'root'
})
export class ContractService {

  constructor(private httpClient: HttpClient) { }

  getContractTypes() {
    return this.httpClient.get<Contract[]>(`${environment.apiUrl}/contracts`)
  }
}
