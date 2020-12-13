import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  constructor(private router: Router) { }

  public handleError = (error: any): Observable<any> => {
    // here might be sending logs to back-end
    //alert(error["error"].Message);

    // console.log(this);
    
    if (error.status === 401) {
      
      this.router.navigate(['sign-in']);
    }
   
    return throwError(error);
  }
}
