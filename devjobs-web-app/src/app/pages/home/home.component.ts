import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { JobcardComponent } from '../../components/jobcard/jobcard.component';
import { SearchbarComponent } from '../../components/searchbar/searchbar.component';
import { RouterModule } from '@angular/router';
import { JobService } from '../../services/job.service';
import { JobSummary, SearchFilter } from '../../@types';
import { Observable } from 'rxjs';

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
  searchFilter: SearchFilter = {
    query: '',
    location: '',
    fullTimeOnly: false
  };

  constructor(private jobService: JobService) { }

  onFilterChange(searchFilter: SearchFilter): void {
    this.searchFilter = searchFilter;
  }
}
