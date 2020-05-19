import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { ProfileComponent } from './components/profile/profile.component';
import {ProductService} from './shared/services/product.service';
import {UserService} from './shared/services/user.service';
import { LoginComponent } from './components/login/login.component';
import { ProductPageComponent } from './components/product-page/product-page.component';
import { SingupComponent } from './components/singup/singup.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AuthService } from './shared/services/auth.service';
import { MaindbService } from './shared/services/maindb.service';
import {Ng2PageScrollModule} from 'ng2-page-scroll';
import { EventBusService } from './shared/services/event-bus.service';
import { SearchProductComponent } from './components/search-product/search-product.component';

import { SearchProductPipe } from './shared/pipes/search-product.pipe';
import { ClickOutsideDirective } from './shared/directives/dropdown.directive';
import { ProductListComponent } from './components/product-list/product-list.component';
import { CartComponent } from './components/cart/cart.component';
import { ProductComponent } from './components/product-list/product/product.component';
import { CartProductComponent } from './components/cart/cart-product/cart-product.component';
import { OrderPanelComponent } from './components/cart/order-panel/order-panel.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ProductListComponent,
    ProfileComponent,
    CartComponent,
    LoginComponent,
    ProductPageComponent,
    ProductComponent,
    SingupComponent,
    CartProductComponent,
    OrderPanelComponent,
    SearchProductComponent,
    SearchProductPipe,
    ClickOutsideDirective,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    Ng2PageScrollModule,
    HttpClientInMemoryWebApiModule.forRoot(
      MaindbService, { dataEncapsulation: false }
    ),
    BrowserAnimationsModule,
    MatSelectModule
  ],
  providers: [ProductService, UserService, AuthService, EventBusService],
  bootstrap: [AppComponent]
})
export class AppModule { }
