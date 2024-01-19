import { Routes } from '@angular/router';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';
import { CreateUserComponent } from './create-user/create-user.component';
import { LoginComponentComponent } from './login-component/login-component.component';

export const routes: Routes = [
    {
        path:'',
        component:LoginComponentComponent
    },
    {
        path:'employees',
        component:EmployeeListComponent
    },
    {
        path:'addUser',
        component:CreateUserComponent
    }
    
];
