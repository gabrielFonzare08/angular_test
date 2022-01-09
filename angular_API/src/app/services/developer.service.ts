import { Injectable } from '@angular/core';
import {HttpClient , HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import {Observable , throwError} from 'rxjs';
import{retry ,catchError} from 'rxjs/operators';
import{Developer} from '../models/developer';


@Injectable({
  providedIn: 'root'
})
export class DeveloperService {

  url = 'http://localhost:3000/developers';

  constructor(private httpClient: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders ({'Content-Type': 'application/json'})
  }

  getDevelopers():Observable<Developer[]>{
    return this.httpClient.get<Developer[]>(this.url).pipe(retry(2),catchError(this.handleError))
  }

  getDeveloperById(id:number) : Observable<Developer>{
    return this.httpClient.get<Developer>(this.url + '/' + id).pipe(retry(2),catchError(this.handleError)
    )
  }

  createDeveloper(dev: Developer): Observable<Developer>{
      return this.httpClient.post<Developer>(this.url, dev ,this.httpOptions)
      .pipe(retry(2),catchError(this.handleError))
  }

  updateDeveloper(dev:Developer) : Observable<Developer>{
    return this.httpClient.put<Developer>(this.url + '/' + dev.id, JSON.stringify(dev), this.httpOptions)
      .pipe(retry(1),catchError(this.handleError)
      )
  }

  deleteDeveloper(dev: Developer) {
    return this.httpClient.delete<Developer>(this.url + '/' + dev.id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) { errorMessage = error.error.message;
    } else {
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}