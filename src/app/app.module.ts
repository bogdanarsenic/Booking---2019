import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CheckavailComponent } from './checkavail/checkavail.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterService } from './register/register.service';
import { LoginService } from './login/login.service';
import { CheckavailService } from './checkavail/checkavail.service';
import {HttpClientModule} from '@angular/common/http';
import { HttpClientXsrfModule } from '@angular/common/http';
import { GuestComponent } from './guest/guest.component';
import { AllUsersComponent } from './all-users/all-users.component';

const appRoutes:Routes=[
  
  { path:'',component:CheckavailComponent},
  { path:'checkavail',component:CheckavailComponent},
  { path:'login',component:LoginComponent},
   {path: 'guest',component:GuestComponent},
   {path:'register',component:RegisterComponent},
   {path:'home',component:HomeComponent},
   
];


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CheckavailComponent,
    HomeComponent,
    NavbarComponent,
    GuestComponent,
    AllUsersComponent,
    
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    HttpClientXsrfModule
  ],
  providers: [RegisterService,LoginService,CheckavailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
