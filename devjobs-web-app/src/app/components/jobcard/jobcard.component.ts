import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-jobcard',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './jobcard.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class JobcardComponent { }
