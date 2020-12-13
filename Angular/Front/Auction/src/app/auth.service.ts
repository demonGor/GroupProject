import { LoginModel } from './login-model';
import { UserModel } from './user-model';
import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap, timeout, switchMap, delay } from 'rxjs/operators';
import { ErrorHandlerService } from './error-handler.service';
import { TokenService } from './token.service';
import { RegisterModel } from './register-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit {
  ngOnInit(): void {
    this.getCurrentUser(this.tokenService.getToken()).subscribe(x=>this.currentUser=x)
  }

  constructor(private httpClient: HttpClient, private errorService:ErrorHandlerService, private tokenService:TokenService) 
  {
    this.getCurrentUser(this.tokenService.getToken()).subscribe(x=>this.currentUser=x,error=>this.tokenService.clearToken());
   }
  token: any;
  currentUser: UserModel;

  // I would return an observable to indicate if it was a successful log in or not.
  // Subscribe and check result where signIn method was called
  public signIn(model: LoginModel): Observable<UserModel> {
    const PATH1 = 'http://localhost:50723/Token';
    // var data = "username=" + model.Email + "&grant_type=password" + "&password=" + model.Password;
    const data = `username=${model.Email}&grant_type=password&password=${model.Password}`;

    return this.httpClient.post(PATH1, data)
      .pipe(
        map(data => data['access_token']),
        // tap just do something on current data
        tap(token => {
          this.tokenService.persistToken(token);
        }),
        switchMap((token: string) => {
          return this.getCurrentUser(token);
        }),
        tap(user => this.currentUser = user),
        catchError(this.errorService.handleError)
      );
    // i would prefer to return observable/ If you do not want, do subscribe here
    // .subscribe(
    //   (user: User) => {
    //     console.log((user as User));
    //     this.currentUser = user;
    //   }
    // );
  }

  public getCurrentUser(token: string): Observable<UserModel> {
    const PATH2 = 'http://localhost:50723/api/CurrentUser';
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${token}` });
    return this.httpClient.get<UserModel>(PATH2, { headers: reqHeader });
  }

  // can return an observable of user also
  public getUser(): UserModel {
    return this.currentUser;
  }

  public singUp(loginModel: RegisterModel): Observable<UserModel> {
    const PATH = 'http://localhost:50723/api/Account/Register';
    var reqHeader = new HttpHeaders({ 'Authorization': `Bearer ${this.tokenService.getToken()}` });

    return this.httpClient.post<any>(PATH, loginModel).pipe(
      tap(),
      catchError(this.errorService.handleError)
    );

  }

  public signOut():Observable<void> {
    return of(null).pipe(
      delay(1500),
      tap(() => {
        this.currentUser=null;
        this.tokenService.clearToken();
      })
    )
  }

  public isSignedIn():boolean{
    return this.getUser()!=null;
  }

}
