import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from "@angular/common/http";
import { SolverPagedResponse, SolverResponse } from '../models/solver-response.model';
import { ISolverService } from './solver-api.service';

@Injectable({
  providedIn: 'root'
})

export class SolverService implements ISolverService {
  private readonly APIUrl: string = "https://localhost:7121/api/";
  constructor(private http: HttpClient) {
  }

  getTableData(databaseId: string, schema: string, tableName: string, pageNumber?: number, pageSize?: number): Observable<SolverPagedResponse> {
    console.log('HTTPget');
    console.log(`Page Number: ${pageNumber}`);
    console.log(`Page Size: ${pageSize}`);
    console.log(`DatabaseId: ${databaseId}`);
    console.log(`Schema: ${schema}`);
    console.log(`Table Name: ${tableName}`);
    console.log(this.APIUrl + databaseId + '/data/' + schema + '/' + tableName);
    let params = new HttpParams();
    if (pageNumber) {
      params = params.set("PageNumber", pageNumber.toString());
    }
    if (pageSize) {
      params = params.set("PageSize", pageSize.toString());
    }
    return this.http.get<any>(this.APIUrl + databaseId + '/data/' + schema + '/' + tableName, { params: params });
  }
    
  generateCsv(databaseId: string, schema: string, tableName: string): Observable<SolverResponse> {
    console.log('HTTPpost');
    console.log(`DatabaseId: ${databaseId}`);
    console.log(`Schema: ${schema}`);
    console.log(`Table Name: ${tableName}`);
    console.log(this.APIUrl + databaseId + '/data/' + schema + '/' + tableName);
    const headers = { 'content-type': 'application/json' }
    return this.http.post<any>(this.APIUrl + databaseId + '/data/' + schema + '/' + tableName, null, { headers: headers });
  }
}
