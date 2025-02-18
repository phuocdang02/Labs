import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  username = '';
  password = '';
  errorMessage?: string;

  constructor(private http: HttpClient) {}

  onRegister() {
    const data = {
      username: this.username,
      password: this.password,
    };

    this.http.post<any>('/register', data).subscribe({
      next: (response) => console.log('Registered: ', response),

      error: (error) => {
        this.errorMessage = error.message || 'Register failed.';
        console.error('Registered error: ', error);
      },
    });
  }
}
