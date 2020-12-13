import { AuthService } from './../auth.service';
import { Category } from './../models/Category';
import { Component, OnInit } from '@angular/core';
import { TokenService } from '../token.service';
import { HttpClient } from '@angular/common/http';
import { CategoriesService } from '../categories.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

 Categories:Category[];
  constructor(private authService:AuthService, private httpClient:HttpClient, private categoryService:CategoriesService, private router:Router) { }

  ngOnInit() {
    this.getAllCategories();
  }

 

  public getAllCategories():void{
    this.categoryService.getCategories().subscribe(categories=>this.Categories=categories);
  }

  public deleteCategory(Id:number){
    var status = confirm("Видалити цю категорію");
    if(status==true)
      this.categoryService.deleteCategory(Id).subscribe(()=>{alert("Успішно видалено"), this.getAllCategories()}, error => alert("Не вдалося видалити") );
  
    }

    public routeToItemsByCategory(id:number):void
    {
      this.router.navigate([`itemsByCategory/${id}`]);
    }
    public routeToCategorycreate():void
    {
      this.router.navigate([`category-create`]);
    }
    

    public get isAdmin$():boolean{
      return this.authService.currentUser.Role == 'admin';
    }

    public get isUserSignedIn$(): boolean {
      return this.authService.isSignedIn();
    }

}
