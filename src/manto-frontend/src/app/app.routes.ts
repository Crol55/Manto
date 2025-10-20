import { Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './login/login.component';
import { BoardDetailComponent } from './boards/board-detail/board-detail.component';

export const routes: Routes = [
    {path:"", component:LoginComponent},
    {path:"home", component:LandingPageComponent},
    {path:"boards/:id", component: BoardDetailComponent}
];
