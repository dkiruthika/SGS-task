import { Component } from '@angular/core';
import { UserServicesService } from '../services/user-services.service';
import { User } from '../interfaces/user';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent {
  user : User = {
    id : 0,
    name : "",
    email : "",
    password : "",
    isActive : true

  }
  constructor(private userService:UserServicesService,private router:Router) {
  
}
  addUser(){
    this.userService.addUser(this.user)
    .subscribe({
      next : (user) => {
        console.log("User Added!");
        this.router.navigate(['/employees'])
      }
    })
  }
}
