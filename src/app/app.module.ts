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
import { AdminComponent } from './admin/admin.component';
import { HostComponent } from './host/host.component';
import { AllReservationsComponent } from './all-reservations/all-reservations.component';
import { AllApartmantsComponent } from './all-apartmants/all-apartmants.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { CommentsComponent } from './comments/comments.component';
import { AddHostComponent } from './add-host/add-host.component';

const appRoutes:Routes=[
  
  { path:'',component:CheckavailComponent},
  { path:'checkavail',component:CheckavailComponent},
  { path:'login',component:LoginComponent},
   {path: 'guest/:Id',component:GuestComponent},
   {path: 'admin/:Id',component:AdminComponent},
   {path: 'host/:Id',component:HostComponent},
   {path:'register',component:RegisterComponent},
   {path:'home',component:HomeComponent},
   {path:'host',component:HostComponent},
   {path:'admin/:Id/AllUsers',component:AllUsersComponent},
   {path:'admin/:Id/AllReservations',component:AllReservationsComponent},
   {path:'admin/:Id/AllApartmants',component:AllApartmantsComponent},
   {path:'admin/:Id/EditProfile',component:EditProfileComponent},
   {path:'host/:Id/EditProfile',component:EditProfileComponent},
   {path:'guest/:Id/EditProfile',component:EditProfileComponent},
   {path:'admin/:Id/AddHost',component:AddHostComponent}
   
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
    AdminComponent,
    HostComponent,
    AllReservationsComponent,
    AllApartmantsComponent,
    EditProfileComponent,
    CommentsComponent,
    AddHostComponent,
    
    
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
