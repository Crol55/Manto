import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { BoardDetail } from '../../common/models/BoardDetail.model';


@Component({
  selector: 'app-board-overview',
  standalone: true,
  imports: [MatGridListModule, MatIconModule, RouterModule],
  templateUrl: './board-overview.component.html',
  styleUrl: './board-overview.component.scss'
})

export class BoardOverviewComponent implements OnChanges{
  
  //boards = [ 
  //  {id:"2", name: "USAC", icon: "favorite"},
  //  {id:"2", name: "Landivar", icon: "favorite"},
  //  {id:"2", name: "Intel", icon: "favorite"},
  //  {id:"2", name: "Dell", icon: "favorite"}
  //];

  @Input() BoardsList: BoardDetail [] = [];

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
