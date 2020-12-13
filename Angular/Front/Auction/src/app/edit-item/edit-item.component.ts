import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { TokenService } from '../token.service';
import { CategoriesService } from '../categories.service';
import { ItemsService } from '../items.service';
import { Category } from '../models/Category';
import { Item } from '../models/Item';

@Component({
  selector: 'app-edit-item',
  templateUrl: './edit-item.component.html',
  styleUrls: ['./edit-item.component.css']
})
export class EditItemComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router:Router,private authService:AuthService, private tokenService:TokenService, private categoryService:CategoriesService,private itemService:ItemsService) {
    
   }
  
   public item:Item;
   
  Categories:Category[];
  public selectedCategory:Category;
  
  
  ngOnInit() {
    this.getAllCategories();
    this.getItemById();
    
    
  }
  public getAllCategories()
  {
    this.categoryService.getCategories().subscribe(categories=>{this.Categories=categories; },error=>this.router.navigate([`myItems`]));

  }
  public getItemById():void
  {
    const id=+this.route.snapshot.paramMap.get('id');
    this.itemService.getItemById(id).subscribe(x=>this.item=x, error=>this.router.navigate([`myItems`]));
  }

  public getCategoryById(id:number):void
  {
   
    this.categoryService.getCategoryById(id).subscribe(x=>{this.selectedCategory; console.log(x.Name)},error=>this.router.navigate([`myItems`]));
  }

  public updateItem()
  {
      this.itemService.updateItem(this.item.Id, this.item).subscribe(_ => {
      this.router.navigate([`myItems`]); alert("Успішно оновлено")
    }, (error) => {alert("Не вдалося оновити");  this.router.navigate([`myItems`]); });
  }

}
