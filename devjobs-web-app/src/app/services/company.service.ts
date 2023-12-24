import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ElementRef, Injectable } from '@angular/core';
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

  getSvgLogo(element: ElementRef, companyName: string) {
    const headers = new HttpHeaders();
    headers.set('Accept', 'image/svg+xml');
    this.httpClient.get(
        `${environment.apiUrl}/logos/${companyName.replace(' ', '').toLowerCase()}.svg`,
        { headers, responseType: 'text' }
      ).subscribe({
        next: (v) => {
          const parser = new DOMParser();
          const { documentElement } = parser.parseFromString(v, "image/svg+xml");
          element.nativeElement.appendChild(documentElement);
      }
    });
  }

}
