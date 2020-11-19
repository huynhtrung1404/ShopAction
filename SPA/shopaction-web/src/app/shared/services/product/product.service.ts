import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Product } from '../../Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  endpoint : string = 'https://localhost:5001/api/Products';
  header = new HttpHeaders().set('Content-Type','application/json');
  constructor(
    private http: HttpClient
  ) { }

  getProductById(productId: string, languageId: string ): Observable<Product>{
    let api = `${this.endpoint}/getProductById/${productId}/${languageId}`;
    return this.http.get<Product>(api)
    .pipe(catchError(this.handleError))
  }
  
  //Error
  handleError(error: HttpErrorResponse){
    let mgs = '';
    if (error.error instanceof ErrorEvent) {
      mgs = error.error.message;
    }
    else {
      mgs = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(mgs);
  }
}
