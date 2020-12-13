import { Bid } from './../models/Bid';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { TokenService } from '../token.service';
import { CategoriesService } from '../categories.service';
import { ItemsService } from '../items.service';
import { Item } from '../models/Item';

@Component({
  selector: 'app-create-bid',
  templateUrl: './create-bid.component.html',
  styleUrls: ['./create-bid.component.css']
})
export class CreateBidComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router:Router,private authService:AuthService, private tokenService:TokenService, private categoryService:CategoriesService,private itemService:ItemsService) { }
 public Amount:number;
 public item:Item;

  ngOnInit() {this.getItemById();
  }
  public getItemById():void
  {
    const id=+this.route.snapshot.paramMap.get('id');
    this.itemService.getItemById(id).subscribe(x=>this.item=x, error=>this.router.navigate([`allItems`]));
  }
  public addBid()
  {
   var bid:Bid={
    Id:0, 
   Amount:this.Amount,
   ItemId:this.item.Id,
   
  
    
    UserId:0
    


   }
    this.itemService.createBid(bid).subscribe(_ => {
      this.router.navigate([`allItems`]); alert("Успішно додано")
    }, (error) => {alert("Не вдалося додати");  this.router.navigate([`allItems`]); });
  }
}
