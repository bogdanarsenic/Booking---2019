import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {User} from '../models/User';
import {AllUsersService} from '../all-users/all-users.service';


@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent implements OnInit {

  allUsers:User[];
  user:User;


  constructor(private router:Router, private allUserService:AllUsersService) { }

  ngOnInit() {
    localStorage.setItem('CurrentComponent','AllUsers')

    if(localStorage.getItem('CurrentRole')=="Admin")
    {
        this.user=new User("","","","","","","");
        this.allUserService.GetAllUsers().subscribe(
          data=>
          {
            this.allUsers=data;
          }
        )

    }
  }

 
}
