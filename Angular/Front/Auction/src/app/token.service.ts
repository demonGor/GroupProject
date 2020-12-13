import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TokenService {


  constructor() { }

  public persistToken(token:string):void{
    console.log('token string parsed and saved to local storage');
    console.log(token);
    localStorage.setItem('rawToken', token);
  }

  public getToken():string{
    const token = localStorage.getItem('rawToken');
    return token;
  }

  public clearToken():void{
    localStorage.removeItem('rawToken');
  }

  public hasToken():boolean{
    if(localStorage.getItem('rawToken')!=null)
      return true;
    else
      return false;
  }
}
