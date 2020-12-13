import { AuthService } from './../auth.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {

  @Input() username: string;
  @Input() password: string;

  constructor(private router: Router, private authService: AuthService) { }

  login(): void {
    this.authService.signIn({
      Email: this.username,
      Password: this.password
    }).subscribe(() => {
      // redirect to dashboards route
     this.router.navigate(['main-page']);
    }, () => {
      alert('Invalid credentials');
    });
  }

}
