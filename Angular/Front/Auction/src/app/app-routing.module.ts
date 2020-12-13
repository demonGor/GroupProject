import { SignUpComponent } from './sign-up/sign-up.component';
import { MainPageComponent } from './main-page/main-page.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './sign-in/sign-in.component';
import { UserListComponent } from './user-list/user-list.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { MyItemsListComponent } from './my-items-list/my-items-list.component';
import { LiveItemsListComponent } from './live-items-list/live-items-list.component';
import { AllItemsListComponent } from './all-items-list/all-items-list.component';
import { ItemsByCategoryComponent } from './items-by-category/items-by-category.component';
import { CategoryCreateComponent } from './category-create/category-create.component';
import { CreateItemComponent } from './create-item/create-item.component';
import { EditItemComponent } from './edit-item/edit-item.component';
import { CreateBidComponent } from './create-bid/create-bid.component';
import { BidDetailsComponent } from './bid-details/bid-details.component';

const routes: Routes = [
  { path: 'maxBidForItem/:id', component: BidDetailsComponent },
  { path: 'createBid/:id', component: CreateBidComponent },
  { path: 'updateItem/:id', component: EditItemComponent },
 { path: 'item-create', component: CreateItemComponent },
  { path: 'category-create', component: CategoryCreateComponent },
  { path: 'itemsByCategory/:id', component: ItemsByCategoryComponent },
  { path: 'allItems', component: AllItemsListComponent },
  { path: 'liveItems', component: LiveItemsListComponent },
  { path: 'myItems', component: MyItemsListComponent },
  { path: 'sign-in', component: SignInComponent },
  { path: 'categories', component: CategoryListComponent },
  { path: 'main-page', component: MainPageComponent },
  {path:'', component: MainPageComponent},
  { path: 'sign-up', component: SignUpComponent },
  { path: 'users', component: UserListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
