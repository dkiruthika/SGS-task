import { Component,ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ModalComponent } from './modal/modal.component';
import { ModalService } from './popupservice.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ModalComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(private modalService: ModalService) {}
  openModal() {
    this.modalService.showModal();
  }
  
}
