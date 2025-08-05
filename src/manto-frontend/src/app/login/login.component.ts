import { AfterViewInit, Component, ElementRef, inject, ViewChild } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { HttpErrorResponse, HttpStatusCode } from '@angular/common/http';
import { SnackbarService, LogType } from '../services/snackbar.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatIconModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor (private router:Router, 
               private loginService:LoginService,
               private _snackbarService:SnackbarService,
               private _authService:AuthService){
              }

  isPasswordVisible:boolean = false;

  public togglePasswordVisiblity()
  {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  public onLogin(email:string, password:string){

    if(this.isEmpty(email) || this.isEmpty(password)){
      window.alert('The fields Email and Password, cant be empty');
      return;
    }
    
    this.loginService.login(email, password)
    .subscribe({
      next: (response) =>{

        if(response.ok){
          this.router.navigate(['home']);
          this._snackbarService.openSimpleSnackBar("Welcome Back", LogType.Success,  undefined, 2000);
          this._authService.setAccessToken(response.body!.jwt);
          
        }
      }, 
      error: (err: HttpErrorResponse) =>{
          this._snackbarService.openSimpleSnackBar(err.error.title, LogType.Error, "close", 6000 );
      }
    });

  }

  private isEmpty(value:string):boolean
  {
    return value.trim() === '';
  }
}
