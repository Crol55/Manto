import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable(
  {providedIn:'root'}
)
export class LoginService {
  
  private PORT:number = 7118;
  private URL:string = `https://localhost:${this.PORT}/login`;

  constructor(private httpClient: HttpClient) { 

    console.log(`the final url is -> ${this.URL}`);
    
  }

  login(user:string, password:string): Observable<HttpResponse<LoginResponse>> 
  {
    const body = {
      emailOrUsername: user, 
      password: password
    };
    
    return this.httpClient.post<LoginResponse>(
      this.URL, 
      body,
      { observe: 'response'}
    );
  }
}

export interface LoginResponse{
  jwt:string
}
