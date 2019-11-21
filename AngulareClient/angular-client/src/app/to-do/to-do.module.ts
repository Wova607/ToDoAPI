import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddToDoItemComponent } from './add-to-do-item/add-to-do-item.component';
import { ToDoItemComponent } from './to-do-item/to-do-item.component';
import { ToDoListComponent } from './to-do-list/to-do-list.component';



@NgModule({
  declarations: [AddToDoItemComponent, ToDoItemComponent, ToDoListComponent],
  imports: [
    CommonModule
  ]
})
export class ToDoModule { }
