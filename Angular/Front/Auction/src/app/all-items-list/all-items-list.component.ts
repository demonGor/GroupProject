import { Component, OnInit } from '@angular/core';
import { Item } from '../models/Item';
import { AuthService } from '../auth.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ItemsService } from '../items.service';

@Component({
  selector: 'app-all-items-list',
  templateUrl: './all-items-list.component.html',
  styleUrls: ['./all-items-list.component.css']
})
export class AllItemsListComponent implements OnInit {

  Items:Item[];
  constructor(private authService:AuthService, private httpClient:HttpClient, private router:Router, private itemService:ItemsService) { }

  ngOnInit() {
    this.getMyItems()
    
  }

  
  public get isAdmin$():boolean{
    return this.authService.currentUser.Role == 'admin';
  }
  
  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }
  public getMyItems()
  {
    this.itemService.getAllItems().subscribe(x=>this.Items=x);
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
      this.router.navigate([`maxBidForItem/${id}`]);
}

}
