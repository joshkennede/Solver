import { Observable } from "rxjs";
import { SolverPagedResponse } from "src/app/models/solver-response.model";

export interface ISolverService {
  /**
   * Get Table Data
   * @param databaseId
   * @param schema
   * @param tableName
   * @param pageNumber
   * @param pageSize
   */
  getTableData(databaseId: string, schema: string, tableName: string, pageNumber?: number, pageSize?: number): Observable<SolverPagedResponse>;

  /**
   * Generate a CSV file from a table
   * @param databaseId
   * @param schema
   * @param tableName
   */
  generateCsv(databaseId: string, schema: string, tableName: string): Observable<SolverPagedResponse>;
}
