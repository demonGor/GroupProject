import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import { SignInComponent } from './sign-in/sign-in.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import {FormsModule} from '@angular/forms';
import { MainPageComponent } from './main-page/main-page.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UserListComponent } from './user-list/user-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { AllItemsListComponent } from './all-items-list/all-items-list.component';
import { LiveItemsListComponent } from './live-items-list/live-items-list.component';
import { MyItemsListComponent } from './my-items-list/my-items-list.component';
import { ItemsByCategoryComponent } from './items-by-category/items-by-category.component';
import { CategoryCreateComponent } from './category-create/category-create.component';
import { CreateItemComponent } from './create-item/create-item.component';
import { EditItemComponent } from './edit-item/edit-item.component';
import { CreateBidComponent } from './create-bid/create-bid.component';
import { ResultComponent } from './result/result.component';
import { BidDetailsComponent } from './bid-details/bid-details.component'


@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    NavBarComponent,
    MainPageComponent,
    SignUpComponent,
    UserListComponent,
    CategoryListComponent,
    AllItemsListComponent,
    LiveItemsListComponent,
    MyItemsListComponent,
    ItemsByCategoryComponent,
    CategoryCreateComponent,
    CreateItemComponent,
    EditItemComponent,
    CreateBidComponent,
    ResultComponent,
    BidDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
