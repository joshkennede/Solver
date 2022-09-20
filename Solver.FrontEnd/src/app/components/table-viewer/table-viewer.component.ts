import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { SolverService } from 'src/app/services/solver.service';
import { KeyValue } from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

@Component({
  selector: 'app-table-viewer',
  templateUrl: './table-viewer.component.html',
  styleUrls: ['./table-viewer.component.css']
})
export class TableViewerComponent implements OnInit {

  //class instance
  loading: boolean = false;
  generating: boolean = false;

  //input
  databaseId: string = 'adventureworks2019';
  schema: string = 'production';
  tableName: string = 'billofmaterials';
  pageNumber: number | undefined;
  pageSize: number | undefined;

  //output
  response: [] = [];
  columns: string[] = [];

  //pagination
  page: number = 1;

  constructor(private service: SolverService) {}

  ngOnInit(): void {
  }

  getData() {
    this.loading = true;
    return this.service.getTableData(this.databaseId, this.schema, this.tableName, this.pageNumber, this.pageSize)
      .subscribe(s => {
        this.loading = false;
        this.response = s.data;
        this.columns = s.columns;
      });
  }

  generateCSV() {
    this.generating = true;
    return this.service.generateCsv(this.databaseId, this.schema, this.tableName)
      .subscribe(s => {
        this.generating = false;
        alert(s.message);
    });
  }

  onCompare(_left: KeyValue<any, any>, _right: KeyValue<any, any>): number {
    return -1;
  }
}
