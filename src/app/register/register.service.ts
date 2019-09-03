import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpParams} from '@angular/common/http';
import {User} from '../models/User'
import {Observable} from 'rxjs';
import {Register} from '../models/Register'



@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http:HttpClient) { }

  ngOnInit()
  {

  }

  RegisterUser(korisnik:User):Observable<any>
  {
    return this.http.post("http://localhost:53417/api/User/Register",korisnik);

  }

  RegisterHost(korisnik:User):Observable<any>
  {
    return this.http.post("http://localhost:53417/api/User/RegisterHost",korisnik);

  }

  Update(korisnik:User):Observable<any>
  {
    return this.http.post("http://localhost:53417/api/User/Update",korisnik);

  }

  GetUser(Username:string,Password:string):Observable<User>
  {
    return this.http.get<User>(`http://localhost:53417/api/User/GetCurrent`,{params:{Username,Password}});
  }
}
