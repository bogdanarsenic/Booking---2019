import { Component, OnInit, createPlatformFactory } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {User}from '../models/User';
import {RegisterService} from '../register/register.service'
import {Router} from '@angular/router';
import {LoginService} from '../login/login.service'


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  korisnik:User;
  registerUserForm:FormGroup;
  currentUser:User;

  constructor (private fb:FormBuilder,private registerService:RegisterService,private loginService:LoginService,private router:Router){
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

        this.korisnik=data;
        if(data=="Username already exists!")
        {
          alert(data);
        }

        localStorage.setItem('CurrentUsername',data.Username);
        localStorage.setItem('CurrentId',data.Id);
        localStorage.setItem('CurrentRole',data.Role);
        localStorage.setItem('Logged','true');

        this.router.navigateByUrl(`guest/${this.korisnik.Id}`);
        
      }
      
    )

    
    
    this.registerUserForm.reset();
    
  }
  
}
