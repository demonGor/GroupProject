import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { Item } from '../models/Item';
import { HttpClient } from '@angular/common/http';
import { ItemsService } from '../items.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-items-by-category',
  templateUrl: './items-by-category.component.html',
  styleUrls: ['./items-by-category.component.css']
})
export class ItemsByCategoryComponent implements OnInit {
  ngOnInit(): void {
    this.getItemsByCategory();
  }

  Items:Item[];
  constructor(private route:ActivatedRoute, private itemService:ItemsService, private authService:AuthService,private router:Router) { }

  public getItemsByCategory():void
  {
    const id=+this.route.snapshot.paramMap.get('id');
    this.itemService.getItemsByCategory(id).subscribe(items=>this.Items=items);
  }
 

  
  public get isAdmin$():boolean{
    return this.authService.currentUser.Role == 'admin';
  }
  
  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }
 
  public deleteItem(Id:number){
    var status = confirm("Видалити цей лот");
    if(status==true)
      this.itemService.deleteItem(Id).subscribe(()=>{alert("Успішно видалено"), this.itemService.getLiveItems()}, error => alert("Не вдалося видалити") );


}
public routeToBid(id:number){
  this.router.navigate([`createBid/${id}`]);
}
public routeToEdit(id:number):void
    {
      this.router.navigate([`updateItem/${id}`]);
    }
    public showWinner(id:number){
      this.router.navigate([`maxBidForItem/${id}`]);}
}
