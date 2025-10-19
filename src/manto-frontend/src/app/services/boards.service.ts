import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Observable, tap } from 'rxjs';
import { Board, BoardDetailDto, BoardResponse } from '../common/models/board.model';

@Injectable({
  providedIn: 'root'
})
export class BoardsService {

  constructor(
    private httpClient: HttpClient, 
    private authService: AuthService
  )
  {}

  private boardCollection = new Map<string, Board>();

  private readonly PORT:number = 7120;
  private readonly URL:string = `https://localhost:${this.PORT}/boards`;


  // ** get's methods
  public getBoardsWhereUserIsMember(): Observable<HttpResponse<BoardDetailDto[]>>{

    const httpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.getAccessToken()}`
    });

    return this.httpClient.get<BoardDetailDto[]>(this.URL, {
      headers: httpHeaders,
      observe: 'response'
    });
  }

  public getBoard(boardId: string)
  {
    const endpoint = `${this.URL}/${boardId}`;

    const httpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.getAccessToken()}`
    });

    return this.httpClient.get<BoardDetailDto>(endpoint, {
      headers: httpHeaders
    });

  }
  

  // ** post's methods
  public postNewBoard(boardName: string, projectId?:string){

    const httpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.getAccessToken()}`
    });

    let body = {
      Name: boardName, 
      projectId: null
    }
    
    return this.httpClient.post<BoardResponse>(this.URL, body, {
      headers: httpHeaders,
      observe:'response'
    })/*.pipe(tap({
      next: response => {
        if (response.ok)
          this.boardCollection.set(response.body!.boardId, { id});
      }
    }))*/;
  }

  // ** Helper methods

  public saveBoard(board:Board) // This should be the only way for updating the collection of boards
  {
    this.boardCollection.set(board.id, board);
  }

  public retrieveBoard(key: string)
  {
    return this.boardCollection.get(key);
  }
}

