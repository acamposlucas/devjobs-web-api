import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CompanyCardComponent } from '../../components/company-card/company-card.component';

@Component({
  selector: 'app-job',
  standalone: true,
  imports: [
    CommonModule,
    CompanyCardComponent
  ],
  templateUrl: './job.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class JobComponent { }
