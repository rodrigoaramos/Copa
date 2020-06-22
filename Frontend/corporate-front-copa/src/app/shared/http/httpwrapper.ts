import { Injectable } from '@angular/core';
import { environment } from './../../../environments/environment';
import { Observable, of, throwError } from 'rxjs';
import { catchError, tap, map, retry } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

const baseAddress = environment.apiConfig.baseApiAddress;

@Injectable({
  providedIn: 'root'
})
export class HttpWrapper {

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  delete(url: string, id: number): Observable<any> {
    const urlApi = `${baseAddress}/${url}/${id}`;
    return this.http.delete<any>(urlApi);
  }

  get(url: string, params?: string): Observable<any> {
    const urlApi = `${baseAddress}/${url}?${params}`;
    return this.http.get<any>(urlApi);
  }

  post(url: string, body: any | null): Observable<any> {
    const urlApi = `${baseAddress}/${url}`;
    return this.http.post(urlApi, body, this.httpOptions);
  }

  put(url: string, body: any | null): Observable<any> {
    const urlApi = `${baseAddress}/${url}`;
    return this.http.put(urlApi, body);
  }

  handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        errorMessage = error.error.message;
      } else {
        errorMessage = `Codigo do erro: ${error.status}, ` + `menssagem: ${error.message}`;
      }
      console.log(errorMessage);
      return of(result as T);
    };
  }
}
