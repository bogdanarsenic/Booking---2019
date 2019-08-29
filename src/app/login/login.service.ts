import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpParams} from '@angular/common/http';
import {Login} from '../models/Login';
import {User} from '../models/User'
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  user:User;
  constructor(private http:HttpClient) { }

  ngOnInit()
  {
      this.user=new User("","","","","","","");
  }

  GetUser(Username:string,Password:string):Observable<User>
  {
    return this.http.get<User>(`http://localhost:53417/api/User/GetCurrent`,{params:{Username,Password}});
  }
}
