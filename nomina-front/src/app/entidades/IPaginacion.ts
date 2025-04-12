export interface PaginacionResponse<T> {
  items: T[];
  totalCount: number;
}

export interface PaginacionRequest {
  page: number;
  pageSize: number;
  sortField: string;
  sortDirection: string;
  filter: string;
}
