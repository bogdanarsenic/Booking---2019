import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import {LoginService} from '../login/login.service'
import {Router} from '@angular/router';
import {Login} from '../models/Login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  korisnik:Login;
  loginUserForm:FormGroup;

  constructor(private fb:FormBuilder,private loginService:LoginService,private router:Router)
  {
    this.createForm();
   }

   createForm()
   {
     this.loginUserForm=this.fb.group(
       {
         username: ['',Validators.required],
         password: ['',Validators.required]
       }
     );

     }
   
  ngOnInit() {
    localStorage.setItem('CurrentComponent','LoginComponent');
  }

 /* onSubmit()
  {
    this.korisnik=this.loginUserForm.value;
    console.log(this.korisnik); 

    this.loginService.GetUser(this.korisnik.Username,this.korisnik.Password).subscribe(
      data=>{
        if(data=="Username already exists!")
        {
          alert(data);
        }
      }
    )

    this.router.navigateByUrl("/guest");
    this.loginUserForm.reset();
  }
*/

}
