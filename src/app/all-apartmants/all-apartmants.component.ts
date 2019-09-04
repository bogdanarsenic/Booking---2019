import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-all-apartmants',
  templateUrl: './all-apartmants.component.html',
  styleUrls: ['./all-apartmants.component.css']
})
export class AllApartmantsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    localStorage.setItem('CurrentComponent','AllApartmantsComponent');
  }

}
