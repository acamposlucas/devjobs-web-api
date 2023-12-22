import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, Renderer2, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Company } from '../../@types/Company';
import { CompanyService } from '../../services/company.service';
import { Observable } from 'rxjs';
import { JobService } from '../../services/job.service';
import { CreateJob } from '../../@types';

@Component({
  selector: 'app-new-job',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './new-job.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewJobComponent {
  companies: Observable<Company[]> = this.companyService.getCompanies();
  @ViewChild('requirements') requirementsContainer!: ElementRef<HTMLDivElement>;
  @ViewChild('roles') rolesContainer!: ElementRef<HTMLDivElement>;

  form = this.fb.group({
    companyId: [''],
    position: [''],
    contractType: [''],
    location: [''],
    description: [''],
    requirements: this.fb.array([this.fb.group({ value: '' })]),
    roles: this.fb.array([this.fb.group({ value: '' })]),
  })

  constructor(private renderer: Renderer2, private fb: FormBuilder, private companyService: CompanyService, private jobService: JobService) {
  }

  addItem(type: string): void {
    if (type === 'requirements') {
      this.requirements.push(this.fb.group({ value: '' }));
    } else if (type === 'roles') {
      this.roles.push(this.fb.group({ value: '' }));
    }
  }

  onSubmit() {
    const newJob: CreateJob = this.form.getRawValue() as CreateJob;
    this.jobService.createJob(newJob);
  }

  get requirements() {
    return this.form.controls['requirements'] as FormArray;
  }

  get roles() {
    return this.form.controls['roles'] as FormArray;
  }
}
