import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryItemComponent } from './category-item/category-item.component';
import { AddCategoryItemComponent } from './add-category-item/add-category-item.component';



@NgModule({
  declarations: [CategoryItemComponent, AddCategoryItemComponent],
  imports: [
    CommonModule
  ]
})
export class CategoryModule { }
