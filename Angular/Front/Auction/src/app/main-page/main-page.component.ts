import { AuthService } from './../auth.service';
import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(private authService:AuthService) { }

  ngOnInit() {
    if(this.authService.isSignedIn())
    this.userName = this.authService.getUser().Name;
  }

  userName:string=null;

  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }

  public get UserName$():string
  {
return this.authService.getUser().Name;
  }



}
