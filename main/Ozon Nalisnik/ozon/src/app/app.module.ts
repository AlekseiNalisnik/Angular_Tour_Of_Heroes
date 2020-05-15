import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';

import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule, MatFormFieldControl } from '@angular/material/form-field';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

import { NgxPageScrollModule } from 'ngx-page-scroll';
import { NgxPageScrollCoreModule } from 'ngx-page-scroll-core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { MainComponent } from './components/main/main.component';
import { HeaderComponent } from './components/header/header.component';
import { BasketComponent } from './components/basket/basket.component';
import { ProfileComponent } from './components/profile/profile.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ProductComponent } from './components/product/product.component';
import { AuthorizationComponent } from './components/authorization/authorization.component';
import { MainProductComponent } from './components/main/main-product/main-product.component';
import { BasketProductComponent } from './components/basket/basket-product/basket-product.component';
// import { SearchComponent } from './components/search/search.component';
import { BasketOrderPanelComponent } from './components/basket/basket-order-panel/basket-order-panel.component';

import { InMemoryDataService }  from './shared/services/in-memory-data.service';
import { SearchProductPipe } from './shared/pipes/search-product.pipe';
import { ClickOutsideDirective } from './shared/directives/dropdown.directive';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    HeaderComponent,
    BasketComponent,
    ProfileComponent,
    RegistrationComponent,
    ProductComponent,
    AuthorizationComponent,
    MainProductComponent,
    BasketProductComponent,
    BasketOrderPanelComponent,
    SearchProductPipe,
    ClickOutsideDirective,
    // SearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false }
    ),
    MatSelectModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule,
    BrowserAnimationsModule,
    NgxPageScrollModule,
    NgxPageScrollCoreModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
