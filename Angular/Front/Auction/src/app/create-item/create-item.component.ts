import { Item } from './../models/Item';
import { Category } from './../models/Category';
import { ItemsService } from './../items.service';
import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../categories.service';
import { TokenService } from '../token.service';
import { AuthService } from '../auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-create-item',
  templateUrl: './create-item.component.html',
  styleUrls: ['./create-item.component.css']
})
export class CreateItemComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router:Router,private authService:AuthService, private tokenService:TokenService, private categoryService:CategoriesService,private itemService:ItemsService) { }
  public Title:string;
  public StartingPrice:number;
  public Description:string;
  public MinIncrease:number;
  public  StartTime:Date;
  public  EndTime:Date;
  public  Image?:string;
   
  Categories:Category[];
  public selectedCategory:Category;
  
  
  ngOnInit() {
    this.getAllCategories();
  }
  public getAllCategories()
  {
    this.categoryService.getCategories().subscribe(categories=>{this.Categories=categories; this.selectedCategory=this.Categories[0];});

  }

  public addItem()
  {
   var item:Item={
    Id:0, 
    Title:this.Title,
    StartingPrice:this.StartingPrice,
    StartTime:this.StartTime,
    EndTime:this.EndTime,
    Image:this.Image,
    Description:this.Description,
    MinIncrease:this.MinIncrease,
    CategoryId:this.selectedCategory.Id, 
    UserId:0
    


   }
    this.itemService.createItem(item).subscribe(_ => {
      this.router.navigate([`myItems`]); alert("Успішно додано")
    }, (error) => {alert("Не вдалося додати");  this.router.navigate([`myItems`]); });
  }
}
