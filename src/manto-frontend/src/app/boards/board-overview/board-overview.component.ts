import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { BoardDetailDto } from '../../common/models/board.model';


@Component({
  selector: 'app-board-overview',
  standalone: true,
  imports: [MatGridListModule, MatIconModule, RouterModule],
  templateUrl: './board-overview.component.html',
  styleUrl: './board-overview.component.scss'
})

export class BoardOverviewComponent implements OnChanges{
  
  @Input() BoardsList: BoardDetailDto [] = [];

  ngOnChanges(changes: SimpleChanges): void {

    //if(changes["BoardsList"]){
    //  console.log("Hubo cambio");
    //  this.BoardsList.forEach( x =>{
    //    this.boards.push( { id: x.boardId, name:x.boardName, icon:"favorite"});
    //  });
    //   
    //}
  }
}
