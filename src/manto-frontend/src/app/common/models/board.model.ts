
export interface Board {
  id: string;
  name: string;
  userId: string;
  createdAt: Date;
  project: string | null;
}

export interface BoardDetailDto {

  boardId: string;
  boardName: string;
  userId: string;
  joiningDate: Date;
  TypeOfMembership: string;
}


export interface BoardResponse {
  boardId: string,
  name: string,
  createdAt: Date,
  userId: string,
  projectId?: string
}


export class BoardMapper {

  static fromDTO(dto: BoardDetailDto): Board{

    return {
      id: dto.boardId,
      name: dto.boardName,
      userId: dto.userId,
      createdAt: new Date(),
      project : null
    };
  }
}


