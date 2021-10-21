import { Injectable } from '@angular/core';
import { Student } from './student-model';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'http://localhost:5000/Students'
  formData: Student = new Student();
  list: Student[];

  postStudent() {
    return this.http.post(this.baseURL, this.formData);
  }

  putStudent() {
    return this.http.put(this.baseURL, this.formData);
  }

  deleteStudent(id: string) {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        idNumber: `${id}`,
      },
    };

    return this.http.delete(`${this.baseURL}`,options);
    //return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList() {
    this.http.get("http://localhost:5000/getall")
      .subscribe(res =>
      {
        this.list = res["data"] as Student[];
        
      }, err => {
          console.log(err);
      });
     
  }
}
