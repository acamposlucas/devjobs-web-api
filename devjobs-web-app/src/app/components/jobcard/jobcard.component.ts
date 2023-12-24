import { CommonModule } from '@angular/common';
import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, Input, ViewChild } from '@angular/core';
import { JobSummary } from '../../@types/Job';
import { DateAgoPipe } from '../../pipes/dateAgo.pipe';
import { environment } from '../../../environments/environment.development';
import { CompanyService } from '../../services/company.service';

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
export class JobcardComponent implements AfterViewInit {
  @Input({ required: true }) job!: JobSummary;

  @ViewChild('logo') logo!: ElementRef<HTMLDivElement>;

  API_URL = environment.apiUrl;

  constructor(private companyService: CompanyService) { }

  ngAfterViewInit(): void {
    this.companyService.getSvgLogo(this.logo, this.job.company)
  }
}
