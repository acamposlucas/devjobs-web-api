import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  },
  {
    path: "job/:id",
    loadComponent: () => import('./pages/job/job.component').then(m => m.JobComponent)
  },
  {
    path: "createJob",
    loadComponent: () => import('./pages/new-job/new-job.component').then(m => m.NewJobComponent),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
