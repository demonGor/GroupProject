import { AuthService } from './auth.service';
import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login-model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    /*
    var model:LoginModel = {
      Email:"User",
      Password:"passwordUser"
    }
    
    this.service.signIn(model).subscribe(u=>console.log(u));
*/
  }
  title = 'Service';
  constructor(private service:AuthService){

  }
}
