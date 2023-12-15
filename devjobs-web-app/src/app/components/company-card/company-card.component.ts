import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, Input, ViewChild } from '@angular/core';
import { Company } from '../../@types/Company';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-company-card',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './company-card.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompanyCardComponent {
  @Input({ required: true }) company!: Company;

  @ViewChild('logo') logo!: ElementRef<HTMLDivElement>;

  API_URL = environment.apiUrl;

  constructor(private httpClient: HttpClient) {

  }
  ngOnInit(): void {
    this.getSvgLogo();
  }

  getSvgLogo() {
    const headers = new HttpHeaders();
    headers.set('Accept', 'image/svg+xml');
    const svgString = this.httpClient.get(`${this.API_URL}/logos/${this.company.name.toLowerCase()}.svg`, { headers, responseType: 'text' }).subscribe({
      next: (v) => {
        const parser = new DOMParser();
        const { documentElement } = parser.parseFromString(v, "image/svg+xml");
        this.logo.nativeElement.appendChild(documentElement);
      }
    });

    return svgString;
  }
}
