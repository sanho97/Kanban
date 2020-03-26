import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Task } from './models/task.model';
import { List, ListModel } from './models/list';
import {Observable, throwError} from 'rxjs';
import {catchError, retry} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class Service {

  // Base url
  baseurl = 'https://localhost:44301/api';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  // GET ALL TASK LIST
  GetList(): Observable<List[]> {
    return this.http.get<List[]>(this.baseurl + `/lists/`)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // PUT List
  UpdateListPosition(data) {
      return this.http.put(this.baseurl + `/lists/position`, JSON.stringify(data), this.httpOptions)
        .pipe(
          retry(1),
          catchError(this.errorHandl)
        );
  }
  //
  // PUT
  UpdateTask(id, data): Observable<Task> {
    return this.http.put<Task>(this.baseurl + '/tasks/' + id, JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  //
  // Error handling
  errorHandl(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
