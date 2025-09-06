import { Component, Input, OnInit } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { ListWrapperComponent } from '../list-wrapper/list-wrapper.component';
import { ListComponent } from '../list/list.component';
import { FocusDirective } from '../../../common/directives/focus.directive';
import { ListsService } from '../../../services/lists.service';
import { ListCreate } from '../../../common/models/listCreate.model';

@Component({
  selector: 'app-list-container',
  standalone: true,
  imports: [MatIconModule, ListWrapperComponent, ListComponent, FocusDirective],
  templateUrl: './list-container.component.html',
  styleUrl: './list-container.component.css'
})
export class ListContainerComponent implements OnInit{

  @Input() boardId!: string;

  boardLists: ListCreate[] = [{name: "Usac-Test", position:0, boardId: this.boardId}];
  isAddingList:boolean = false;

  constructor(private _listsService:ListsService){
    
  }

  ngOnInit(): void {
    //manana (Jueves) hay que arreglar que existen 2 o mas formas de agregar informacion a this.boardLists (y solo debe existir una)
    this._listsService.getLists(this.boardId).subscribe({
      next: (data)=>{
        if (data.ok)
          this.boardLists = data.body ?? [];
      },
      error: (err)=> {}
    });
  }
  
  toggleAddListForm(){
    this.isAddingList = !(this.isAddingList);
  }

  onAddList (listName:string){

    this.boardLists.push( { 
      name:listName,
      position: 0,
      boardId: this.boardId 
    })

    let newList:ListCreate = {
      name: listName, 
      position:0, 
      boardId: this.boardId
    }; 

    this._listsService.postNewList(newList);
    
    this.toggleAddListForm();
  }
}
