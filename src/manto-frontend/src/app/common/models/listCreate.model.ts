//export interface ListCreate {
//    name: string,
//    position: number,
//    boardId: string
//}

export interface BoardList {
    name: string,
    position: number,
    createdAt: Date,
    updatedAt: Date,
    boardId: string | null
}

export type ListCreate = Pick<BoardList, "name" | "position" | "boardId">;
