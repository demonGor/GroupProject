import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyItemsListComponent } from './my-items-list.component';

describe('MyItemsListComponent', () => {
  let component: MyItemsListComponent;
  let fixture: ComponentFixture<MyItemsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyItemsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyItemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
