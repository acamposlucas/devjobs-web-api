import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-company-card',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './company-card.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompanyCardComponent { }
