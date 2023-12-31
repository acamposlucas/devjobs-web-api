import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Job, JobSummary } from '../@types/Job';
import { environment } from '../../environments/environment.development';
import { CreateJob } from '../@types';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private httpClient: HttpClient) { }

  getJobsSummariesList() {
    return this.httpClient.get<JobSummary[]>(`${environment.apiUrl}/jobs/summaries`);
  }

  getJobById(id: number) {
    return this.httpClient.get<Job>(`${environment.apiUrl}/jobs/${id}`);
  }

  createJob(job: CreateJob) {
    this.httpClient.post<CreateJob>(`${environment.apiUrl}/jobs`, job).subscribe();
  }
}
