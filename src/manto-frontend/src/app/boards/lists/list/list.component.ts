import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { CardComponent} from '../card/card.component'
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [CardComponent, MatIconModule, FormsModule],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss'
})
export class ListComponent {

  @Input() listName:string = "";
  @ViewChild("cardNameTextAreaRef") textAreaRef!: ElementRef<HTMLTextAreaElement>;

  public cardslist = ["Backlog-error", "printing (undefined)"];
  protected isAddingCard:boolean = true;
  cardName:string = '';

  public openNewCardForm(){
    this.isAddingCard = true;
   
    setTimeout(() => {
      this.textAreaRef?.nativeElement.focus();
    });
  }

  public addNewCard(){
    
    this.textAreaRef.nativeElement.blur(); //prevent unwanted 'Enter/new-line' to be inserted into the textarea. 

    this.cardslist.push(this.cardName);
    this.cardName = '';

    console.log(this.textAreaRef?.nativeElement.value === 'abc');
    
  }

  public closeNewCardForm(){
    this.isAddingCard = false;
  }


}
