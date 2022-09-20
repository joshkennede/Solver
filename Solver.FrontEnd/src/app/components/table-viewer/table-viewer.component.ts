import { Component, OnInit } from '@angular/core';
import { SolverService } from 'src/app/services/solver.service';
import { KeyValue } from '@angular/common';

@Component({
  selector: 'app-table-viewer',
  templateUrl: './table-viewer.component.html',
  styleUrls: ['./table-viewer.component.css']
})
export class TableViewerComponent implements OnInit {
  public formMessage = "Please fill out all fields";
  public validationMessage: string | undefined;
  public loading: boolean = false;
  public generating: boolean = false;
  public databaseId: string = '';
  public schema: string = '';
  public tableName: string = '';
  public response: [] | undefined;
  public columns: string[] | undefined;
  public message: string | undefined;
  public page: number = 1;
  public pageNumber: number | undefined;
  public pageSize: number | undefined;

  constructor(private service: SolverService) {}

  ngOnInit(): void {
  }

  getData() {
    if (this.isFormComplete(this.databaseId, this.schema, this.tableName)) {
      this.loading = true;
      return this.service.getTableData(this.databaseId, this.schema, this.tableName, this.pageNumber, this.pageSize)
        .subscribe(s => {
          this.loading = false;
          this.response = s.data;
          this.columns = s.columns;
          this.message = s.message;
        });
    } else {
      return this.validationMessage = this.formMessage;
    }
  }

  generateCSV() {
    this.generating = true;
    return this.service.generateCsv(this.databaseId, this.schema, this.tableName)
      .subscribe(s => {
        this.generating = false;
        alert(s.message);
    });
  }

  isFormComplete(databaseId: string, schema: string, tableName: string): boolean {
    if (!databaseId || !schema || !tableName) {
      return false;
    }
    return true;
  }

  onCompare(_left: KeyValue<any, any>, _right: KeyValue<any, any>): number {
    return -1;
  }
}
