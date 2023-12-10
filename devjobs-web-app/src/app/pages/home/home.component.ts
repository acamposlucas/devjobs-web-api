import { CommonModule } from '@angular/common';
import { AfterContentInit, ChangeDetectionStrategy, Component } from '@angular/core';
import { JobcardComponent } from '../../components/jobcard/jobcard.component';
import { SearchbarComponent } from '../../components/searchbar/searchbar.component';
import { RouterModule } from '@angular/router';
import { JobService } from '../../services/job.service';

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

  constructor(private jobService: JobService) { }
}
