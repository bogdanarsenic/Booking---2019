import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {LoginService} from '../login/login.service'
import {Router} from '@angular/router';
import {Login} from '../models/Login';
import { User } from '../models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login:Login;
  currentUser:User;
  loginUserForm:FormGroup;

  constructor(private fb:FormBuilder,private loginService:LoginService,private router:Router)
  {
    this.createForm();
   }

   createForm()
   {
     this.loginUserForm=this.fb.group(
       {
         Username: ['',Validators.required],
         Password: ['',Validators.required]
       }
     );

     }
   
  ngOnInit() {
    localStorage.setItem('CurrentComponent','LoginComponent');
    this.login=new Login("","");
    this.currentUser=new User("","","","","","","");
  }

 onSubmit()
  {
    this.login=this.loginUserForm.value;
  
    console.log(this.login); 

    this.loginService.GetUser(this.login.Username,this.login.Password).subscribe(
      data=>{
        this.currentUser=data;
        if(data==null)
        {
          alert("Invalid username or password");
        }

        localStorage.setItem('CurrentUsername',data.Username);
        localStorage.setItem('CurrentId',data.Id);
        localStorage.setItem('CurrentRole',data.Role);
        localStorage.setItem('Logged','true');

        if(this.currentUser.Role=="Admin")
        {
            this.router.navigateByUrl(`/admin/${this.currentUser.Id}`);
        }

        if(this.currentUser.Role=="Host")
        {
          this.router.navigateByUrl(`/host/${this.currentUser.Id}`);
        }

        if(this.currentUser.Role=="Guest")
        {
          this.router.navigateByUrl(`/guest/${this.currentUser.Id}`);
        }
        

      },error => {
        alert("Error!")
        console.log(error);
      }
    )

    
    this.loginUserForm.reset();
  }


}
