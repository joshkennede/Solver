export class SolverResponse {

  data: [];
  columns: [];
  succeeded: boolean;
  errors: [];
  message: string;

  constructor(
    data: [],
    columns: [],
    succeeded: boolean,
    errors: [],
    message: string) {
    this.data = data;
    this.columns = columns;
    this.succeeded = succeeded;
    this.errors = errors;
    this.message = message;
  }
}

export class SolverPagedResponse {

  data: [];
  columns: [];
  succeeded: boolean;
  errors: [];
  message: string;
  pageNumber: number;
  pageSize: number;
  firstPage: string;
  lastPage: string;
  totalPages: number;
  totalRecords: number;
  nextPage: string;
  previousPage: string;
  
  constructor(
    data: [],
    columns: [],
    succeeded: boolean,
    errors: [],
    message: string,
    pageNumber: number,
    pageSize: number,
    firstPage: string,
    lastPage: string,
    totalPages: number,
    totalRecords: number,
    nextPage: string,
    previousPage: string) {
    this.data = data;
    this.columns = columns;
    this.succeeded = succeeded;
    this.errors = errors;
    this.message = message;
    this.pageNumber = pageNumber;
    this.pageSize = pageSize;
    this.firstPage = firstPage;
    this.lastPage = lastPage;
    this.totalPages = totalPages;
    this.totalRecords = totalRecords;
    this.nextPage = nextPage;
    this.previousPage = previousPage;
  }
}









