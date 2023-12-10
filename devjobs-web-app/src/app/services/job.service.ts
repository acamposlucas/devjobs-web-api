import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JobSummary } from '../@types/Job';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private httpClient: HttpClient) { }

  getJobsSummariesList() {
    return this.httpClient.get<JobSummary[]>(`${environment.apiUrl}/jobs/summaries`);
  }
}
