import { Component, OnInit, createPlatformFactory } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {User}from '../models/User';
import {RegisterService} from '../register/register.service'
import {Router} from '@angular/router';
import {LoginService} from '../login/login.service'
import { Login } from '../models/Login';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  korisnik:User;
  registerUserForm:FormGroup;
  currentUser:Login;
  user:User;

  constructor (private fb:FormBuilder,private registerService:RegisterService,private loginService:LoginService,private router:Router){
    this.createForm();
  }
  
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

  
  ngOnInit()
  {
      localStorage.setItem('CurrentComponent','RegisterComponent');
      this.korisnik=new User("","","","","","","");
      this.currentUser=new Login("","");
  }

  onSubmit()
  {
    this.korisnik=this.registerUserForm.value;
    this.currentUser.Username=this.korisnik.Username;
    this.currentUser.Password=this.korisnik.Password;

    console.log(this.korisnik);

    this.registerService.RegisterUser(this.korisnik).subscribe(
      data=>{

            this.korisnik=data;
            if(data=="Username already exists!")
            {
              alert(data);
            } 
      
            this.registerService.GetUser(this.currentUser.Username,this.currentUser.Password).subscribe(
              data=>{
                      this.user=data;
                      localStorage.setItem('Logged','true');
                      this.router.navigateByUrl(`/guest/${this.user.Id}`);
                     }
            )
                    }
    )

    

    this.registerUserForm.reset();
    
    
  }
  
}