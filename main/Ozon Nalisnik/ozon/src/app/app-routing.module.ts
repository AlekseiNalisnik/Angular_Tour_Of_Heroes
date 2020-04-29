import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MainComponent } from './main/main.component';
import { BasketComponent } from './basket/basket.component';
import { RegistrationComponent } from './registration/registration.component';
import { ProfileComponent } from './profile/profile.component';
import { ProductComponent } from './product/product.component';

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
