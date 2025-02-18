import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private http: HttpClient) {}

  onLogin() {
    const data = {
      username: this.username,
      password: this.password,
    };

    this.http.post('/login', data).subscribe(
      (response) => {},
      (error) => {}
    );
  }
}
