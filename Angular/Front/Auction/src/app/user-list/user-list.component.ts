import { AuthService } from './../auth.service';
import { UsersService } from './users.service';

import { TokenService } from './../token.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../models/User';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  Users:User[];
  constructor(private tokenService:TokenService, private httpClient:HttpClient, private userService:UsersService) { }

  ngOnInit() {
    this.getAllUsers();
  }

 

  public getAllUsers():void{
    this.userService.getUsers().subscribe(users=>this.Users=users);
  }

  public deleteUser(Id:number){
    var status = confirm("Видалити цього користувача");
    if(status==true)
      this.userService.deleteUser(Id).subscribe(()=>{alert("Успішно видалено"), this.getAllUsers()}, error => alert("Не вдалося видалити") );
  
    }

}
