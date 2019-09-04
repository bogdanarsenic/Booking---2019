import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AllApartmantsComponent } from './all-apartmants.component';

describe('AllApartmantsComponent', () => {
  let component: AllApartmantsComponent;
  let fixture: ComponentFixture<AllApartmantsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AllApartmantsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AllApartmantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
