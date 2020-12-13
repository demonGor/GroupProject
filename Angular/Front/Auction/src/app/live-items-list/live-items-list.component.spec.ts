import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LiveItemsListComponent } from './live-items-list.component';

describe('LiveItemsListComponent', () => {
  let component: LiveItemsListComponent;
  let fixture: ComponentFixture<LiveItemsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LiveItemsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LiveItemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
