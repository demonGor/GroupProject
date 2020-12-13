import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Item } from './models/Item';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';
import { AuthService } from './auth.service';
import { ErrorHandlerService } from './error-handler.service';
import { tap, catchError } from 'rxjs/operators';
import { Bid } from './models/Bid';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  constructor(private tokenService:TokenService, private httpClient:HttpClient, private authService:AuthService, private errorService:ErrorHandlerService) { }

  public getItemsByCategory(id:number):Observable<Item[]> {
    const PATH2 = `http://localhost:50723/api/Categories/${id}/Items`;
    
    return this.httpClient.get<Item[]>(PATH2);
  }
  public search(word:string):Observable<Item[]>{
    const PATH2 = `http://localhost:50723/api/Items/${word}`;
    
    return this.httpClient.get<Item[]>(PATH2);
  }

  public getItemById(id:number):Observable<Item> {
    const PATH2 = `http://localhost:50723/api/ItemsBy/${id}`;
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
    return this.httpClient.get<Item>(PATH2, { headers: reqHeader });
  }


  public createItem(item:Item)
  {
    const PATH2 = 'http://localhost:50723/api/Items';
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
   
    return this.httpClient.post<any>(PATH2, item, { headers: reqHeader }).pipe(
      tap(),
      catchError(this.errorService.handleError)
    );
  }

  public createBid(bid:Bid)
  {
    const PATH2 = 'http://localhost:50723/api/Bids';
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
   
    return this.httpClient.post<any>(PATH2, bid, { headers: reqHeader }).pipe(
      tap(),
      catchError(this.errorService.handleError)
    );
}
    public deleteItem(Id:number):Observable<void>{
      const PATH2 = `http://localhost:50723/api/Items/${Id}`;
      var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
      return this.httpClient.delete<void>(PATH2, { headers: reqHeader });

    
  }

  public getLiveItems():Observable<Item[]> {
    const PATH2 = `http://localhost:50723/api/LiveItems`;
    
    return this.httpClient.get<Item[]>(PATH2);
  }
  public getAllItems():Observable<Item[]> {
    const PATH2 = `http://localhost:50723/api/Items`;
    
    return this.httpClient.get<Item[]>(PATH2);
  }

  public getMyItems():Observable<Item[]> {
    const PATH2 = `http://localhost:50723/api/MyItems`;
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
    return this.httpClient.get<Item[]>(PATH2, { headers: reqHeader });
  }

  public getHighestAmountForItem(Id:number):Observable<Bid>{
    const PATH2 = `http://localhost:50723/api/Items/${Id}/HighestBid`;
    
    return this.httpClient.get<Bid>(PATH2);

  
}
public updateItem(Id: number, item: Item): Observable<{}> {
  const PATH2 = `http://localhost:50723/api/Items/${Id}`;
  var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
  return this.httpClient.put(PATH2,item, { headers: reqHeader });
}
}
