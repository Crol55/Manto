
export interface BoardList {
    id:string,
    name: string,
    position: number ,
    createdAt: Date,
    updatedAt: Date,
    boardId: string// | null
}

export type ListCreate = Pick<BoardList, "name" | "position" | "boardId">;

export type ListUpdateDto = Pick<BoardList, "name" | "position">

export type ListResponseDto = Pick<BoardList, "id" |"name" | "position" | "boardId">;
