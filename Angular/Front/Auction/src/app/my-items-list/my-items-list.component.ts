import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { HttpClient } from '@angular/common/http';
import { CategoriesService } from '../categories.service';
import { Router } from '@angular/router';
import { ItemsService } from '../items.service';
import { Item } from '../models/Item';

@Component({
  selector: 'app-my-items-list',
  templateUrl: './my-items-list.component.html',
  styleUrls: ['./my-items-list.component.css']
})
export class MyItemsListComponent implements OnInit {
  Items:Item[];
  constructor(private authService:AuthService, private httpClient:HttpClient, private categoryService:CategoriesService, private router:Router, private itemService:ItemsService) { }

  ngOnInit() {
    this.getMyItems()
    
  }

  
  public get isAdmin$():boolean{
    return this.authService.currentUser.Role == 'admin';
  }

  public getMyItems()
  {
    this.itemService.getMyItems().subscribe(x=>this.Items=x);
  }
  public deleteItem(Id:number){
    var status = confirm("Видалити цей лот");
    if(status==true)
      this.itemService.deleteItem(Id).subscribe(()=>{alert("Успішно видалено"), this.getMyItems()}, error => alert("Не вдалося видалити") );


}

public routeToEdit(id:number):void
    {
      this.router.navigate([`updateItem/${id}`]);
    }
public routeToItemCreate():void
    {
      this.router.navigate([`item-create`]);
    }
    public showWinner(id:number){
      this.router.navigate([`maxBidForItem/${id}`]);}


}
