import { CommonModule } from '@angular/common';
import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { JobSummary } from '../../@types/Job';
import { DateAgoPipe } from '../../pipes/dateAgo.pipe';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-jobcard',
  standalone: true,
  imports: [
    CommonModule,
    DateAgoPipe
  ],
  templateUrl: './jobcard.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class JobcardComponent implements OnInit {
  @Input({ required: true }) job!: JobSummary;

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
    const svgString = this.httpClient.get(`${this.API_URL}/logos/${this.job.company.toLowerCase()}.svg`, { headers, responseType: 'text' }).subscribe({
      next: (v) => {
        const parser = new DOMParser();
        const { documentElement } = parser.parseFromString(v, "image/svg+xml");
        this.logo.nativeElement.appendChild(documentElement);
      }
    });

    return svgString;
  }
}
