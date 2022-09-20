import { Component, OnInit } from '@angular/core';
import { SolverService } from 'src/app/services/solver.service';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-table-viewer',
  templateUrl: './table-viewer.component.html',
  styleUrls: ['./table-viewer.component.css']
})
export class TableViewerComponent implements OnInit {

  loading: boolean = false;
  generating: boolean = false;
  databaseId: string = '';
  schema: string = '';
  tableName: string = '';
  response: [] | undefined;
  columns: string[] | undefined;
  message: string | undefined;
  page: number = 1;
  pageNumber: number | undefined;
  pageSize: number | undefined;

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
        this.message = s.message;
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
