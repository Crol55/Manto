import { Component, OnInit} from '@angular/core';
import { MatIconModule} from '@angular/material/icon'
import { BoardOverviewComponent } from '../boards/board-overview/board-overview.component';
import { BoardsService } from '../services/boards.service';
import { BoardDetail } from '../common/models/BoardDetail.model';
import { FocusDirective } from '../common/directives/focus.directive';
import { HttpStatusCode } from '@angular/common/http';
import { SnackbarService, LogType } from '../services/snackbar.service';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [MatIconModule, BoardOverviewComponent, FocusDirective],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.scss'
})
export class LandingPageComponent implements OnInit{

  public showBoards = false;
  public showForm = true;

  boards:BoardDetail[] = [];

  constructor(private _boardService:BoardsService, private _snackbarService: SnackbarService) {
    
  }

  public ngOnInit(): void 
  {
    this.initBoards();
  }


  private initBoards(){
    
    this._boardService.getBoardsWhereUserIsMember()
    .subscribe({
      next : (response) =>{
        if(response.ok){
          this.boards = response.body ?? [];
        }
      },
      error: (err) =>{
        console.log("Expected error");
      }
    });

  }

  /** Only this Method is allowed to insert data into the Boards*/
  private addNewBoard( newBoard: BoardDetail)
  {
    this.boards.push(newBoard);
    //verify insertion (should I verify that the insertion was done correctly??????)
    this._snackbarService.openSimpleSnackBar(`Your Board was created`, LogType.Success, "Accept", 3000)
  }


  public openNewBoardForm(event:MouseEvent){
    event.stopPropagation();
    this.showForm = !this.showForm;
  }


  public CreateBoard(boardName: string){

    this._boardService.postNewBoard(boardName).subscribe( {
      next: (response) =>{
          if(response.ok && response.status === HttpStatusCode.Created)
          {
            const newBoard: BoardDetail ={
              boardId: response.body!.boardId,
              boardName: response.body!.name,
              userId: response.body!.userId,
              joiningDate: new Date(),
              TypeOfMembership: 'Owner'
            };
            
            this.addNewBoard(newBoard);
          }
      },
      error: (e) => {
        console.log("Hubo un error en 'postNewBoard'");
        console.log(e);
      }
    });

    this.closeNewBoardForm();
  }

  public toggleBoards(){
    this.showBoards = !this.showBoards;
  }

  public onOpenBoard(boardId:string){
    
  }

  public closeNewBoardForm(){
    this.showForm = false;
  }

}

interface Board{
  id: string;
  name:string;
}