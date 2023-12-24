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

  jobList$ = this.jobService.getJobsSummariesList();
  filteredJobs$: Observable<JobSummary[]>
  query: string = '';

  constructor(private jobService: JobService) {
    this.filteredJobs$ = this.jobList$;
  }

  onFilterChange(query: string) {
    this.filteredJobs$ = this.jobList$.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      map(x =>
        x.filter(
          i => i.position.toLowerCase().includes(query.toLowerCase())
        )
      )
    );
  }
}
