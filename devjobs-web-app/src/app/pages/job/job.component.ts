import { CommonModule } from '@angular/common';
import { AfterViewInit, ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CompanyCardComponent } from '../../components/company-card/company-card.component';
import { JobService } from '../../services/job.service';
import { Observable, map, switchMap } from 'rxjs';
import { Job } from '../../@types/Job';
import { ActivatedRoute } from '@angular/router';
import { DateAgoPipe } from '../../pipes/dateAgo.pipe';

@Component({
    selector: 'app-job',
    standalone: true,
    imports: [
        CommonModule,
        CompanyCardComponent,
        DateAgoPipe
    ],
    templateUrl: './job.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class JobComponent {
    job$: Observable<Job>;

    constructor(private jobService: JobService, private route: ActivatedRoute) {
        this.job$ = this.route.paramMap.pipe(
            map((params) => +params.get('id')!),
            switchMap((id) => this.jobService.getJobById(id))
        );
    }
}
