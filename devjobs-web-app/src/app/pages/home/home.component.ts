import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnChanges, SimpleChanges } from '@angular/core';
import { JobcardComponent } from '../../components/jobcard/jobcard.component';
import { SearchbarComponent } from '../../components/searchbar/searchbar.component';
import { RouterModule } from '@angular/router';
import { JobService } from '../../services/job.service';
import { JobSummary } from '../../@types';
import { Observable, debounceTime, distinctUntilChanged, map } from 'rxjs';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    JobcardComponent,
    SearchbarComponent
  ],
  templateUrl: './home.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent {

  jobs$: Observable<JobSummary[]> = this.jobService.getJobsSummariesList();
  query: string = '';

  constructor(private jobService: JobService) { }

  onFilterChange(query: string): void {
    this.query = query;
  }
}
