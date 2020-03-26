import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {Task, TaskModelToEdit} from '../models/task.model';
import {catchError, retry, map} from 'rxjs/operators';
import { Employee } from '../models/employee.model';
import {Checklist} from '../models/Checklist.model';
import {TodoItem, TodoItemModel} from '../models/TodoItem.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  // Base url
  baseurl = 'https://localhost:44301/api';

  constructor(private http: HttpClient) { }

  // Http Headers
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  // GET EMPLOYEES
  GetEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseurl + '/employees/')
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // GET EMPLOYEE
  GetEmployee(id: number): Observable<Employee> {
    return this.http.get<Employee>(this.baseurl + '/employees/' + id)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  //
  // POST
  CreateTask(data): Observable<Task> {
    return this.http.post<Task>(this.baseurl + '/tasks', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // GET TASKS
  GetTask(id): Observable<Task> {
    return this.http.get<Task>(this.baseurl + '/tasks/ ' + id)
      .pipe(map(data => data));
  }

  // DELETE
  DeleteTask(id) {
    return this.http.delete<Task>(this.baseurl + '/tasks/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // PUT
  UpdateTaskName(data): Observable<TaskModelToEdit<string>> {
    return this.http.put<TaskModelToEdit<string>>(this.baseurl + '/tasks/name', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // PUT
  UpdateTaskStartDate(data): Observable<TaskModelToEdit<Date>> {
    return this.http.put<TaskModelToEdit<Date>>(this.baseurl + '/tasks/startdate', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // PUT
  UpdateTaskDuaDate(data): Observable<TaskModelToEdit<Date>> {
    return this.http.put<TaskModelToEdit<Date>>(this.baseurl + '/tasks/duadate', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // PUT
  UpdateTaskAssignEmployee(data): Observable<TaskModelToEdit<number>> {
    return this.http.put<TaskModelToEdit<number>>(this.baseurl + '/tasks/assignemployee', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // PUT
  UpdateTaskOwner(data): Observable<TaskModelToEdit<number>> {
    return this.http.put<TaskModelToEdit<number>>(this.baseurl + '/tasks/owner', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  CreateChecklist(data): Observable<Checklist> {
    return this.http.post<Checklist>(this.baseurl + '/checklists' , JSON.stringify(data), this.httpOptions)
      .pipe(
          retry(1),
          catchError(this.errorHandl)
      );
  }

  // PUT
  UpdateChecklist(id, data): Observable<Checklist> {
    return this.http.put<Checklist>(this.baseurl + '/checklists/' + id, JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // DELETE
  DeleteChecklist(id) {
    return this.http.delete<Checklist>(this.baseurl + '/checklists/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
//
  //
  CreateTodoItem(data): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.baseurl + '/todoitems' , JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // PUT
  UpdateTodoItemName(data): Observable<TodoItemModel<string>> {
    return this.http.put<TodoItemModel<string>>(this.baseurl + '/todoitems/name', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }
  // PUT
  UpdateTodoItemStatus(data): Observable<TodoItemModel<boolean>> {
    return this.http.put<TodoItemModel<boolean>>(this.baseurl + '/todoitems/status', JSON.stringify(data), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }

  // DELETE
  DeleteTodoItem(id) {
    return this.http.delete<TodoItem>(this.baseurl + '/todoitems/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandl)
      );
  }


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
