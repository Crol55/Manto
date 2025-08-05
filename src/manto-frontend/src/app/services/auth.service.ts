import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private TOKEN_KEY:string = "jwt";

  constructor() { }

  public setAccessToken(token:string){
    
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  public getAccessToken():string | null{

    return localStorage.getItem(this.TOKEN_KEY);
  }
}
