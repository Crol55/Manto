import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CustomSnackbarComponent } from '../custom-snackbar/custom-snackbar.component';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private _snackbar:MatSnackBar) { }

  public openSimpleSnackBar(message:string, logType:LogType,  action:string = "Dismiss", duration:number = 3000){

    this._snackbar.open(message, action, {
      duration: duration,
      panelClass: [this.selectStylesToApply(logType)]
    })

    //this._snackbar.openFromComponent( CustomSnackbarComponent );
  }

  private selectStylesToApply(typeOfLog: LogType): string 
  {
    return LogType[typeOfLog].toLowerCase();
  }
}

export enum LogType{
  Success,
  Error,  
  Warning, 
  Info  
}
