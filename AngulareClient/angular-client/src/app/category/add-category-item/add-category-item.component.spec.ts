import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCategoryItemComponent } from './add-category-item.component';

describe('AddCategoryItemComponent', () => {
  let component: AddCategoryItemComponent;
  let fixture: ComponentFixture<AddCategoryItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCategoryItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCategoryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
