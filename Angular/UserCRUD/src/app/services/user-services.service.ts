import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class UserServicesService {
  private baseUrl='https://localhost:7174/'
  public isloggedIn=false
  constructor(private http:HttpClient) { 
  }
  getAllUser() : Observable<User[]>{
    return this.http.get<User[]>(this.baseUrl+'api/user')
  }
  addUser(body:User):Observable<User>{
    return this.http.post<User>(this.baseUrl+'api/User',body)
  }
}
