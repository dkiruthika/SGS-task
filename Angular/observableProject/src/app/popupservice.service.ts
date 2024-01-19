// modal.service.ts
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  private modalStateSubject = new Subject<boolean>();

  showModal() {
    this.modalStateSubject.next(true);
  }

  hideModal() {
    this.modalStateSubject.next(false);
  }

  getModalState() {
    return this.modalStateSubject.asObservable();
  }
}
