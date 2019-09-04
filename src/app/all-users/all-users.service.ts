import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient} from '@angular/common/http';
import {User} from '../models/User';

import { Reservation } from '../models/Reservation';

@Injectable({
  providedIn: 'root'
})
export class AllUsersService {

  constructor(private httpClient:HttpClient) { }

  GetAllUsers():Observable<User[]>
  {
      return this.httpClient.get<User[]>(`http://localhost:53417/api/User/GetAllUsers`);
  }

  GetAllReservationByUsers(Id: string):Observable<User[]>
  {
    return this.httpClient.get<User[]>(`http://localhost:11896/api/User/GetAllReservationByUsers`,{params:{Id}});
  }
}
