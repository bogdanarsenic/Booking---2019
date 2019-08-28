import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpParams} from '@angular/common/http';
import {Login} from '../models/Login';
import {User} from '../models/User'
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  ngOnInit()
  {}

  GetUser(username:User,password:User)
  {
    return this.http.get("http://localhost:53417/api/User/GetCurrent");
  }
}
