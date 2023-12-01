import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';
import { JobcardComponent } from '../../components/jobcard/jobcard.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    JobcardComponent
  ],
  templateUrl: './home.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent { }
