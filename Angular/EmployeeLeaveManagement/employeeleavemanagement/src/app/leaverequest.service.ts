import { Injectable } from '@angular/core';

import { MatDialog } from '@angular/material/dialog';
import { DetailspopupComponent } from './detailspopup/detailspopup.component';

@Injectable({
  providedIn: 'root'
})
export class LeaverequestService {

  constructor(private dialog: MatDialog) { }

  openDetailsPopup(data: any): void {
    this.dialog.open(DetailspopupComponent, {
      width: '400px',
      data: data,
      
    });
  }
}
