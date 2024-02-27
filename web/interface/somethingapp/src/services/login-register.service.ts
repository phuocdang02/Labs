import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface LoginResponse {
  success: boolean;
  message: string;
  data: any; // Adjust data type based on API response
}

interface RegisterResponse {
  // Define properties based on API response
}

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<LoginResponse> {
    return this.http.post<LoginResponse>('http://127.0.0.1/login', {
      email,
      password,
    });
  }

  register(user: any): Observable<RegisterResponse> {
    // Adjust argument type
    return this.http.post<RegisterResponse>('http://127.0.0.1/register', user);
  }
}
