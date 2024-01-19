import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { ModalService } from '../popupservice.service';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.css'
})
export class ModalComponent {
  modalOpen: boolean = false;

  constructor(private modalService: ModalService) {}

  ngOnInit() {
    this.modalService.getModalState().subscribe((isOpen) => {
      this.modalOpen = isOpen;
    });
  }

  
  closeModal() {
    this.modalService.hideModal();
  }
}
