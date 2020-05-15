import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './components/main/main.component';
import { BasketComponent } from './components/basket/basket.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ProductComponent } from './components/product/product.component';

// import { OrderComponent } from './order/order.component';
// import { OrderDetailComponent } from './order-detail/order-detail.component';


const routes: Routes = [
  { path: '', redirectTo: '/products', pathMatch: 'full' },
  { path: 'products', component: MainComponent, children: [
    { path: 'users', component: RegistrationComponent }
  ] },
  { path: 'products/:id', component: ProductComponent },
  { path: 'users', component: RegistrationComponent },

  // { path: 'users/:usersId', component: ProfileComponent },
  { path: 'userProfile', component: ProfileComponent },

  // { path: 'users/:usersId/carts', component: BasketComponent },
  { path: 'basket', component: BasketComponent },

  // { path: 'users:usersId/orders', component: OrderComponent },
  // { path: 'users:usersId/orders:ordersId', component: OrderDetailComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
