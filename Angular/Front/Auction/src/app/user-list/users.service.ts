import { Observable } from 'rxjs';
import { User } from './../models/User';
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { TokenService } from '../token.service';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private tokenService:TokenService, private httpClient:HttpClient, private authService:AuthService) { }

  public getUsers(): Observable<User[]> {
    const PATH2 = 'http://localhost:50723/api/Users';
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
    return this.httpClient.get<User[]>(PATH2, { headers: reqHeader });
  }

  public deleteUser(Id:number):Observable<void>{
    const PATH2 = `http://localhost:50723/api/Users/${Id}`;
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });
    return this.httpClient.delete<void>(PATH2, { headers: reqHeader });
  }
}
