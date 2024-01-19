import { Component } from '@angular/core';
import { LeaverequestService } from '../leaverequest.service';
import { RouterLink, RouterOutlet } from '@angular/router';
import { DetailspopupComponent } from "../detailspopup/detailspopup.component";
import { UserserviceService } from '../userservice.service';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-sharedlayout',
    standalone: true,
    templateUrl: './sharedlayout.component.html',
    styleUrl: './sharedlayout.component.css',
    imports: [RouterOutlet, DetailspopupComponent,RouterLink,CommonModule]
})
export class SharedlayoutComponent {
  constructor(private popupService:LeaverequestService,public userService:UserserviceService){}
  openLeaveRequestPopup(): void {
    const data = { message: 'Details for Leave Request' };
    this.popupService.openDetailsPopup(data);
  }
}
