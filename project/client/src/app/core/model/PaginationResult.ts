export interface PaginationResult<T> {
    index: number;
    totalCount: number;
    count: number;
    data: T[];
}