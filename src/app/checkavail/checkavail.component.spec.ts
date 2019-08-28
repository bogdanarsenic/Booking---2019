import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckavailComponent } from './checkavail.component';

describe('CheckavailComponent', () => {
  let component: CheckavailComponent;
  let fixture: ComponentFixture<CheckavailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CheckavailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CheckavailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
