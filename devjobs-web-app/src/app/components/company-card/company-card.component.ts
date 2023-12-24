import { CommonModule } from '@angular/common';
import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, Input, ViewChild } from '@angular/core';
import { Company } from '../../@types/Company';
import { CompanyService } from '../../services/company.service';

@Component({
  selector: 'app-company-card',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './company-card.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompanyCardComponent implements AfterViewInit {
  @Input({ required: true }) company!: Company;

  @ViewChild('logo') logo!: ElementRef<HTMLDivElement>;

  constructor(private companyService: CompanyService) { }

  ngAfterViewInit(): void {
    this.companyService.getSvgLogo(this.logo, this.company.name);
  }
}
