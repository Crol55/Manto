import { Component } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-board-overview',
  standalone: true,
  imports: [MatGridListModule, MatIconModule, RouterModule],
  templateUrl: './board-overview.component.html',
  styleUrl: './board-overview.component.css'
})

export class BoardOverviewComponent {

   boards = [ 
    {id:1, name: "USAC", icon: "favorite"},
    {id:2, name: "Landivar", icon: "favorite"},
    {id:3, name: "Crayola", icon: "favorite"},
    {id:4, name: "Hershey", icon: "favorite"},
    {id:5, name: "Intel", icon: "favorite"},
    {id:6, name: "Dell", icon: "favorite"}
  ];

  public onBoardSelection(boardId:string)
  {
    // use this or use the [routerLink]
    window.alert("EL tablero seria" + boardId);
  }
}
