import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

// Define interfaces for API responses (adjust data types as needed)
interface LoginResponse {
  success: boolean;
  message: string;
  data: any; // Adjust data type based on API response
}

interface RegisterResponse {
  // Define properties based on API response
}

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [HttpClientModule, FormsModule, RouterOutlet],
})
export class LoginRegisterComponent implements OnInit {
  loginEmail: string = '';
  loginPassword: string = '';
  registerUser: any = {}; // Adjust type

  constructor(private http: HttpClient) {} // Inject HttpClient

  ngOnInit(): void {}

  onLogin() {
    // Send a POST request to the login API endpoint with user credentials
    this.http
      .post<LoginResponse>('http://10.227.1.7:3000/login', {
        email: this.loginEmail,
        password: this.loginPassword,
      })
      .subscribe(
        (response) => {
          // Handle successful login (e.g., store user data, redirect to another page)
          console.log('Login successful:', response);
        },
        (error) => {
          // Handle login error (e.g., display error message)
          console.error('Login error:', error);
        }
      );
  }

  onRegister() {
    // Send a POST request to the register API endpoint with user data
    this.http
      .post<RegisterResponse>(
        'http://10.227.1.7:3000/register',
        this.registerUser
      )
      .subscribe(
        (response) => {
          // Handle successful registration (e.g., display success message, redirect to login)
          console.log('Registration successful:', response);
        },
        (error) => {
          // Handle registration error (e.g., display error message)
          console.error('Registration error:', error);
        }
      );
  }
}
