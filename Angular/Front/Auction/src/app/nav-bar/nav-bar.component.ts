import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private authService:AuthService, private router: Router) { }

  public get isUserSignedIn$(): boolean {
    return this.authService.isSignedIn();
  }

  public get isAdmin$():boolean{
    return this.authService.currentUser.Role == 'admin';
  }

  public signOut(): void {
    this.authService.signOut().subscribe(() => {
      this.router.navigate([''])
    })
  }

}
