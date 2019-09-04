import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {RegisterService} from '../register/register.service';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {User} from '../models/User';
import {Login} from '../models/Login';


@Component({
  selector: 'app-add-host',
  templateUrl: './add-host.component.html',
  styleUrls: ['./add-host.component.css']
})
export class AddHostComponent implements OnInit {

  constructor (private fb:FormBuilder,private registerService:RegisterService,private router:Router){
    this.createForm();
  }

  korisnik:User;
  registerUserForm:FormGroup;
  currentUser:Login;
  user:User;
  id:String;
  
  createForm()
  {
    this.registerUserForm=this.fb.group({
      Username: ['',Validators.required],
      Password:['',Validators.required],
      Name:['',Validators.required],
      Surname:['',Validators.required],
      Gender:['',Validators.required]
    });
  }

  ngOnInit() {
    localStorage.setItem('CurrentComponent','AddHostComponent');
    this.korisnik=new User("","","","","","","");
    this.currentUser=new Login("","");
  }

  onSubmit()
  {
    this.korisnik=this.registerUserForm.value;
    this.currentUser.Username=this.korisnik.Username;
    this.currentUser.Password=this.korisnik.Password;

    console.log(this.korisnik);

    this.registerService.RegisterHost(this.korisnik).subscribe(
      data=>{

            this.korisnik=data;
            if(data=="Username already exists!")
            {
              alert(data);
            } 
      
            this.registerService.GetUser(this.currentUser.Username,this.currentUser.Password).subscribe(
              data=>{

                      this.id=localStorage.getItem('CurrentId');
                      this.router.navigateByUrl(`/admin/${this.user.Id}`);
                     }
            )
                    }
    )

    this.registerUserForm.reset();
    
    
  }


  

}
