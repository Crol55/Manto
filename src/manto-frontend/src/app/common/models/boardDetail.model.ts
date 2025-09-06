export interface BoardDetail {

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



