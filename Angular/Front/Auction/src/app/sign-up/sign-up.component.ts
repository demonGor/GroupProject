import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { RegisterModel } from '../register-model';
import { catchError } from 'rxjs/operators';
import { ErrorHandlerService } from '../error-handler.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  public login: string;
  public password: string;
  public password2: string;

  constructor(private authService: AuthService, private router: Router,private errorService:ErrorHandlerService) { }

  ngOnInit() {
  }
  registerModel:RegisterModel;

  public signUp(): void {
    if (this.password !== this.password2) {
      alert('passwords are differrent!');
      return;
    }
    
    this.authService.singUp({Email:this.login, Password:this.password, ConfirmPassword:this.password2})
    .subscribe(_ => {
      this.router.navigate(['sign-in']);
    }, error => {alert(error["error"].Message); console.log(error);});

    
  }



}
