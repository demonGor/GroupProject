import { Category } from './models/Category';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenService } from './token.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';
import { tap, catchError } from 'rxjs/operators';
import { ErrorHandlerService } from './error-handler.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  

  constructor(private tokenService:TokenService, private httpClient:HttpClient, private authService:AuthService, private errorService:ErrorHandlerService) { }

  public getCategories(): Observable<Category[]> {
    const PATH2 = 'http://localhost:50723/api/Categories';
    return this.httpClient.get<Category[]>(PATH2);
  }

  public deleteCategory(Id:number):Observable<void>{
    const PATH2 = `http://localhost:50723/api/Categories/${Id}`;
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
    return this.httpClient.delete<void>(PATH2, { headers: reqHeader });
  }
  public getCategoryById(Id:number):Observable<Category>{
    const PATH2 = `http://localhost:50723/api/Categories/${Id}`;
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
    return this.httpClient.get<Category>(PATH2, { headers: reqHeader });
  }
  public createCategory(category:Category)
  {
    const PATH2 = 'http://localhost:50723/api/Categories';
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });

    return this.httpClient.post<any>(PATH2, category, { headers: reqHeader }).pipe(
      tap(),
      catchError(this.errorService.handleError)
    );
  }

  }

