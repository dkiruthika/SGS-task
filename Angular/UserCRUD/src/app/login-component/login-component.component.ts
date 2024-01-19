import { Component } from '@angular/core';
import { LoginServiceService } from '../login-service.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { UserServicesService } from '../services/user-services.service';
import { NgToastService } from 'ng-angular-popup';
import { NgToastModule } from 'ng-angular-popup';
@Component({
  selector: 'app-login-component',
  standalone: true,
  imports: [FormsModule,NgToastModule],
  templateUrl: './login-component.component.html',
  styleUrl: './login-component.component.css'
})
export class LoginComponentComponent {

  isLoggedIn=false
  username:string=""
  password:string=""
  
  show = true;
  constructor(private toast:NgToastService, private loginService:LoginServiceService,private router:Router,public userService:UserServicesService){}

  login(){
    
    this.toast.success({detail:'Login Successfull',duration:2000});
    this.loginService.login(this.username,this.password)
    .subscribe({
      next:(response)=>{
        
        this.toast.success({detail:'Login Successfull',duration:2000});
        this.router.navigate(['/employees'])
        this.userService.isloggedIn=true
        
      },
      error:(error)=>{
        this.toast.error({detail:'Invalid username or password',duration:2000});
      }
    });
  }
}
