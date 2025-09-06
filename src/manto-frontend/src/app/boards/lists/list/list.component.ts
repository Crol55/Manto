import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { CardComponent} from '../card/card.component'
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, NgForm } from '@angular/forms';
import { ListCreate } from '../../../common/models/listCreate.model';
import { FocusDirective } from '../../../common/directives/focus.directive';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CardComponent, MatIconModule, FormsModule, FocusDirective],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent {

  @Input() listSpec!: ListCreate;
  @ViewChild("cardNameTextAreaRef") textAreaRef!: ElementRef<HTMLTextAreaElement>;

  public cardslist = ["Backlog-error", "printing (undefined)", "Mouse"];
  protected isAddingCard:boolean = true;
  cardName:string = '';
   
  public addNewCard(){
    
    this.textAreaRef.nativeElement.blur(); //prevent unwanted 'Enter/new-line' to be inserted into the textarea. 

    this.cardslist.push(this.cardName);
    this.cardName = '';

    //this.toggleNewCardForm();
    
  }

  public toggleNewCardForm(){
    this.isAddingCard = !(this.isAddingCard);
  }

  public test(){
    window.alert("he wants to change the name");
  }

}
