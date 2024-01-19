import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserserviceService } from '../userservice.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-loginemployee',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './loginemployee.component.html',
  styleUrl: './loginemployee.component.css'
})
export class LoginemployeeComponent {
username: any;
password: any;
  constructor(public userService : UserserviceService,public router:Router,private snackBar:MatSnackBar){}
  login(){
    this.userService.login(this.username,this.password).subscribe({
      next:(response)=>{
        if(response){
          this.userService.isLoggedIn=true
          this.router.navigate(['/employee'])
        }
        else{
          this.snackBar.open('Login Failed - Invalid Email or Password', 'Ok', {
            duration: 2000,
            panelClass: ['mat-snack-bar-container']
          });
        }
        },
        error:(err)=>{
          this.snackBar.open('Login Failed - Invalid Email or Password', 'Ok', {
            duration: 2000,
            panelClass: ['mat-snack-bar-container']
          });
        }
      }
    )
  }
  ngOnInit(){
    this.userService.isLoggedIn = false
  }
}
