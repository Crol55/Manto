import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { CardComponent} from '../card/card.component'
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { ListResponseDto } from '../../../common/models/listCreate.model';
import { FocusDirective } from '../../../common/directives/focus.directive';
import { ListsService } from '../../../services/lists.service';
import { LogType, SnackbarService } from '../../../services/snackbar.service';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CardComponent, MatIconModule, FormsModule, FocusDirective],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent {

  @Input() listSpec!: ListResponseDto;
  @ViewChild("cardNameTextAreaRef") textAreaRef!: ElementRef<HTMLTextAreaElement>;

  public cardslist = ["Backlog-error", "printing (undefined)", "Mouse"];
  protected isAddingCard:boolean = true;
  cardName:string = '';

  constructor (private _listService:ListsService, private _snackbarService:SnackbarService){}
   
  public addNewCard(){
    
    this.textAreaRef.nativeElement.blur(); //prevent unwanted 'Enter/new-line' to be inserted into the textarea. 

    this.cardslist.push(this.cardName);
    this.cardName = '';

    //this.toggleNewCardForm();
    
  }

  public toggleNewCardForm(){
    this.isAddingCard = !(this.isAddingCard);
  }

  public changeListName(event:Event)
  {
    //updates the listSpec by reference 

    const listNameInputElement =  event.target as HTMLInputElement;

    let newName = (listNameInputElement.value).trim(); 
    listNameInputElement.value = newName;

    this._listService.updateList(this.listSpec.id 
      ,{ 
        name: newName, 
        position: this.listSpec.position
      }
    ).subscribe({
      next: (response) => {
        if(response.ok)
        {
          this.listSpec.name = newName;
          listNameInputElement.blur();
          this._snackbarService.openSimpleSnackBar("Name updated correctly!", LogType.Success)
        }
      },
      error: (err) => {
        console.log("An error ocurred when updating a list: " + err);
      }
    });
  }

}
