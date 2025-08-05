import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute } from '@angular/router';

import { ListContainerComponent } from '../lists/list-container/list-container.component';


@Component({
  selector: 'app-board-detail',
  standalone: true,
  imports: [ CommonModule, MatIconModule, ListContainerComponent],
  templateUrl: './board-detail.component.html',
  styleUrl: './board-detail.component.css'
})
export class BoardDetailComponent implements OnInit{

  boardBackgroundUrl:string = "https://picsum.photos/id/882/1250/800"; 
  boardId:string = "";

  constructor(private activatedRoute:ActivatedRoute){

  }

  ngOnInit (){
    
    this.boardId = this.activatedRoute.snapshot.paramMap.get('id')!;
  }
}
