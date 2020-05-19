import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './components/profile/profile.component';
import {LoginComponent} from './components/login/login.component';
import {ProductPageComponent} from './components/product-page/product-page.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { CartComponent } from './components/cart/cart.component';

const routes: Routes = [
  {path: '', redirectTo: 'product-list', pathMatch: 'full' },
  {path: 'product-list', component: ProductListComponent},
  {path: 'cart', component: CartComponent},
  {path: 'profile/:id', component: ProfileComponent},
  {path: 'product-page/:id', component: ProductPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
