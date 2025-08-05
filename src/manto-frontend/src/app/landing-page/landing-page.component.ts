import { Component } from '@angular/core';
import { MatIconModule} from '@angular/material/icon'
import { BoardOverviewComponent } from '../boards/board-overview/board-overview.component';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [MatIconModule, BoardOverviewComponent],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {

  public showBoards = false;

  boards = [
  { id: "abc-123-A", name: 'USAC' },
  { id: "def-567-B", name: 'Rafael Landivar' },
  // more boards...
  ];

  public CreateBoard(){
    window.alert("your new board will be created");
  }

  public toggleBoards(){
    this.showBoards = !this.showBoards;
  }

  public onOpenBoard(boardId:string){
    
  }
}
