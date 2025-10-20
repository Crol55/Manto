import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';

import { ListContainerComponent } from '../lists/list-container/list-container.component';
import { BoardsService } from '../../services/boards.service';
import { Board, BoardMapper } from '../../common/models/board.model';
import {MatButtonModule} from '@angular/material/button';


@Component({
  selector: 'app-board-detail',
  standalone: true,
  imports: [CommonModule, MatIconModule, ListContainerComponent, MatButtonModule],
  templateUrl: './board-detail.component.html',
  styleUrl: './board-detail.component.scss'
})
export class BoardDetailComponent implements OnInit{

  boardBackgroundUrl:string = "https://picsum.photos/id/882/1250/800"; 
  boardId:string = "";
  boardTitle:string = "";

  constructor(
    private _activatedRoute:ActivatedRoute,
    private _boardService:BoardsService
  ){
  
  }

  ngOnInit ()
  {
    this.boardId = this._activatedRoute.snapshot.paramMap.get('id')!;

    this.getCurrentBoardMetadata();
  }

  getCurrentBoardMetadata():void
  {
    //check if the metadata from current Board is already stored inside the 'source-of-truth'
    let boardMetadata:Board | undefined = this._boardService.retrieveBoard(this.boardId);

    if (boardMetadata)
    {
      this.boardTitle = boardMetadata.name;
      return;
    }
    
    this._boardService.getBoard(this.boardId)
    .subscribe( {
      next: response => { 
        
        this.boardTitle = response.boardName;
        // update the 'source-of-truth'
        this._boardService.saveBoard( BoardMapper.fromDTO(response));
      },
      error: err => {console.log(err);}
    } );
  }

}
