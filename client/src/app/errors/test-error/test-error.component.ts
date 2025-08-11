import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css'],
})
export class TestErrorComponent implements OnInit {
  baseUrl = 'http://localhost:5008/api/';
  validationErrors: string[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/internal-server-error').subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  get400ValidationError() {
    this.http.post(this.baseUrl + 'account/register', {}).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (error) => {
        console.log(error);
        this.validationErrors = error;
      },
    });
  }
}
