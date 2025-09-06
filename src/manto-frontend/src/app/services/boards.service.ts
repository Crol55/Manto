import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Observable } from 'rxjs';
import { BoardDetail, BoardResponse } from '../common/models/BoardDetail.model';

@Injectable({
  providedIn: 'root'
})
export class BoardsService {

  private PORT:number = 7120;
  private URL:string = `https://localhost:${this.PORT}/boards`;

  constructor(private httpClient: HttpClient, private authService: AuthService) { }

  // ** get's methods
  public getBoardsWhereUserIsMember(): Observable<HttpResponse<BoardDetail[]>>{

    const httpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.getAccessToken()}`
    });

    return this.httpClient.get<BoardDetail[]>(this.URL, {
      headers: httpHeaders,
      observe: 'response'
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
    });
  }
}

