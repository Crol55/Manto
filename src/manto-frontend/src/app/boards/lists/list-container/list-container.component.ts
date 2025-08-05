import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { ListWrapperComponent } from '../list-wrapper/list-wrapper.component';
import { ListComponent } from '../list/list.component';

@Component({
  selector: 'app-list-container',
  standalone: true,
  imports: [MatIconModule, ListWrapperComponent, ListComponent],
  templateUrl: './list-container.component.html',
  styleUrl: './list-container.component.css'
})
export class ListContainerComponent {

  boardLists:list[] = [ {name: "Usac"}];
  isAddingList:boolean = false;

  onCloseAddNewList = ()=> this.isAddingList = false;

  onAddNewList = () => this.isAddingList = true;
  
  onAddList (listName:string){
    this.boardLists.push( { name:listName })
  }
}

interface list {
  name:string;
}
