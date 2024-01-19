import { Component } from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {provideNativeDateAdapter} from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
@Component({
  selector: 'app-detailspopup',
  standalone: true,
  imports: [MatDatepickerModule,MatSelectModule],
  providers: [provideNativeDateAdapter()],
  templateUrl: './detailspopup.component.html',
  styleUrl: './detailspopup.component.css'
})
export class DetailspopupComponent {

}
