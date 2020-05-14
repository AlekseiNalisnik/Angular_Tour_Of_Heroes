import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProfileComponent } from './profile/profile.component';
import { CartComponent } from './cart/cart.component';
import {ProductService} from './services/product.service';
import {UserService} from './services/user.service';
import { LoginComponent } from './login/login.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { ProductComponent } from './product-list/product/product.component';
import { SingupComponent } from './singup/singup.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { AuthService } from './services/auth.service';
import { MaindbService } from './services/maindb.service';
import {Ng2PageScrollModule} from 'ng2-page-scroll';
import { CartProductComponent } from './cart/cart-product/cart-product.component';
import { OrderPanelComponent } from './cart/order-panel/order-panel.component';
import { EventBusService } from './services/event-bus.service';
import { SearchProductComponent } from './search-product/search-product.component';


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
