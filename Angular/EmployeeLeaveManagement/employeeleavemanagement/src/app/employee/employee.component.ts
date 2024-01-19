import { Component } from '@angular/core';
import { SharedlayoutComponent } from "../sharedlayout/sharedlayout.component";

@Component({
    selector: 'app-employee',
    standalone: true,
    templateUrl: './employee.component.html',
    styleUrl: './employee.component.css',
    imports: [SharedlayoutComponent]
})
export class EmployeeComponent {

}
