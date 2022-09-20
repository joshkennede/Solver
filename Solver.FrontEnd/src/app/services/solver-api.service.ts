import { Observable } from "rxjs";
import { SolverPagedResponse } from "src/app/models/solver-response.model";

export interface ISolverService {
  /**
   * Get Table Data
   * @param pagingParams
   * @param databaseId
   * @param schema
   * @param tableName
   */
  getTableData(databaseId: string, schema: string, tableName: string, pageNumber?: number, pageSize?: number): Observable<SolverPagedResponse>;

  /**
   * 
   * @param databaseId
   * @param schema
   * @param tableName
   */
  generateCsv(databaseId: string, schema: string, tableName: string): Observable<any>;
}
