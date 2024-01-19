import { Routes } from '@angular/router';
import { LoginemployeeComponent } from './loginemployee/loginemployee.component';
import { EmployeeComponent } from './employee/employee.component';
import { DetailspopupComponent } from './detailspopup/detailspopup.component';

export const routes: Routes = [
     {
         path:'',
         component:LoginemployeeComponent
    },
    {
        path:'employee',
        component:EmployeeComponent,
    },
    {
        path:'leaveRequest',
        component:DetailspopupComponent
    }
    
];
