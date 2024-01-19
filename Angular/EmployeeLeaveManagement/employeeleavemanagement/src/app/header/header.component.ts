import { Component } from '@angular/core';
import { UserserviceService } from '../userservice.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule,MatMenuModule,MatIconModule,MatButtonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  loginSuccess: boolean = this.userService.isLoggedIn;
  constructor(public userService:UserserviceService,public router:Router){}
  logout(){
    this.userService.isLoggedIn=false;
    this.router.navigate([''])
  }
}
