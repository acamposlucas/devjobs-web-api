import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, ElementRef, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';

import { CompanyService } from '../../services/company.service';
import { Observable } from 'rxjs';
import { JobService } from '../../services/job.service';
import { Company, Contract, CreateJob } from '../../@types';
import { ContractService } from '../../services/contract.service';

@Component({
  selector: 'app-new-job',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
  ],
  templateUrl: './new-job.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NewJobComponent {
  companies: Observable<Company[]> = this.companyService.getCompanies();
  contracts: Observable<Contract[]> = this.contractService.getContractTypes();
  @ViewChild('requirements') requirementsContainer!: ElementRef<HTMLDivElement>;
  @ViewChild('roles') rolesContainer!: ElementRef<HTMLDivElement>;

  form = this.fb.group({
    companyId: ['', Validators.compose([Validators.required])],
    position: ['', Validators.compose([Validators.required])],
    contractId: ['', Validators.compose([Validators.required])],
    location: ['', Validators.compose([Validators.required])],
    description: ['', Validators.compose([Validators.required])],
    requirements: this.fb.group({
      content: ['', Validators.compose([Validators.required])],
      items: this.fb.array([this.fb.control('')])
    }),
    roles: this.fb.group({
      content: ['', Validators.compose([Validators.required])],
      items: this.fb.array([this.fb.control('')])
    }),
  })

  constructor(private fb: FormBuilder, private companyService: CompanyService, private jobService: JobService, private contractService: ContractService) {
  }

  addItem(type: string): void {
    if (type === 'requirements') {
      this.requirementItems.push(this.fb.control(''));
    } else if (type === 'roles') {
      this.roleItems.push(this.fb.control(''));
    }
  }

  onSubmit() {
    const newJob: CreateJob = this.form.getRawValue() as CreateJob;
    this.jobService.createJob(newJob);
    this.form.reset();
  }

  get requirements() {
    return this.form.controls['requirements'] as FormGroup;
  }

  get requirementItems() {
    return this.requirements.controls['items'] as FormArray;
  }

  get roles() {
    return this.form.controls['roles'] as FormGroup;
  }

  get roleItems() {
    return this.roles.controls['items'] as FormArray;
  }
}
