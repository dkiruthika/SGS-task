import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Buffer } from 'buffer';
@Injectable({
  providedIn: 'root'
})
export class LoginserviceService {
  private baseUrl='https://localhost:7174/'
  constructor(private http:HttpClient) { 
  }
  login(username:string,password:string):Observable<boolean>{
    const buffer = Buffer.from(password, 'utf-8');
    var user={"emailid":username,"password":buffer.toString('base64')}
    return this.http.post<boolean>(this.baseUrl+'api/Login',user)
  }
}
