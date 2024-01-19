import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { LoginServiceService } from './login-service.service';
import { UserServicesService } from './services/user-services.service';
import { NgToastModule } from 'ng-angular-popup';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,RouterLink,NgToastModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'UserCRUD';
  constructor(private loginService:LoginServiceService,public userService:UserServicesService){}
  

  
}
