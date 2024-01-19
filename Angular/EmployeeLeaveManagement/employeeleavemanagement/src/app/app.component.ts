import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./header/header.component";
import { FooterComponent } from "./footer/footer.component";
import { LoginemployeeComponent } from "./loginemployee/loginemployee.component";
import { UserserviceService } from './userservice.service';
import { SharedlayoutComponent } from './sharedlayout/sharedlayout.component';



@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent, LoginemployeeComponent,SharedlayoutComponent]
})
export class AppComponent {
  title = 'employeeleavemanagement';
  isloggedIn!: boolean;
  constructor(public userService:UserserviceService){
    this.isloggedIn=this.userService.isLoggedIn
  }
}
