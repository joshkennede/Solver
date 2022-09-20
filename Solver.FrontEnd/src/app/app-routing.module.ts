import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableViewerComponent } from './components/table-viewer/table-viewer.component';

const routes: Routes =
[
    { path: '', component: TableViewerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
