import { Component } from '@angular/core';
import { User } from '../../interfaces/user';
import { CommonModule } from '@angular/common';
import { UserServicesService } from '../../services/user-services.service';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent {
  users:User[]=[
    // {
    //   Id:1,
    //   Name:"Kiruthika",
    //   Email:"dkiruthika2012@gmail.com",
    //   Password:"123123",
    //   IsActive:true
    // }
  ];
  constructor(private userServices:UserServicesService) {
    
  }
  ngOnInit():void{
    
    this.userServices.getAllUser().subscribe(
      {
        next:(users) => {
          this.users = users
          console.log(users[0].email);
        }
      }
    )
  }
  
  

}
