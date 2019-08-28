import { Component, OnInit, createPlatformFactory } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {User}from '../models/User';
import {RegisterService} from '../register/register.service'
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  korisnik:User;
  registerUserForm:FormGroup;

  constructor (private fb:FormBuilder,private registerService:RegisterService,private router:Router){
    this.createForm();
  }
  
  createForm()
  {
    this.registerUserForm=this.fb.group({
      username: ['',Validators.required],
      password:['',Validators.required],
      name:['',Validators.required],
      surname:['',Validators.required],
      gender:['',Validators.required]
    });
  }

  
  ngOnInit()
  {
      localStorage.setItem('CurrentComponent','RegisterComponent');
      this.korisnik=new User("","","","","","","");
  }

  onSubmit()
  {
    this.korisnik=this.registerUserForm.value;
    console.log(this.korisnik);

    this.registerService.RegisterUser(this.korisnik).subscribe(
      data=>{
        if(data=="Username already exists!")
        {
          alert(data);
        }
      }
    )

    this.router.navigateByUrl("/guest");
    this.registerUserForm.reset();
    
  }
  
}
