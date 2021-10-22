import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { StudentService } from '../shared/student-service';
import { Student } from '../shared/student-model';
import { HttpResponseBase, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-fetch-students-search',
  templateUrl: './fetch-students-search.component.html',
})
export class FetchStudentsSearchComponent implements OnInit {
  public errorMessage: string;

  constructor(public service: StudentService) { }
  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {

    this.service.refreshList(form.value.searchString);
    this.service.refreshList(form.value['searchString']);
     
    //if (this.service.formData.id == 0)
    //  this.insertRecord(form);
    //else
    //  this.updateRecord(form);
  }

  //insertRecord(form: NgForm) {
  //  this.service.postStudent().subscribe(
  //    res => {
  //      if (res['isSuccess']) {
  //        alert(`Student with IDnumber:${this.service.formData.idNumber}`);
  //      }
  //      this.resetForm(form);
  //      this.service.refreshList();
  //      //this.toastr.success('Submitted successfully', 'Payment Detail Register')
  //    },
  //    err => {
  //      this.errorMessage = (err as HttpErrorResponse).error["error"];
  //      console.log(err);
  //    }
  //  );
  //}

  //updateRecord(form: NgForm) {
  //  this.service.putStudent().subscribe(
  //    res => {
  //      this.resetForm(form);
  //      this.service.refreshList();
  //      //this.toastr.info('Updated successfully', 'Payment Detail Register')
  //    },
  //    err => { console.log(err); }
  //  );
  //}

  //resetForm(form: NgForm) {
  //  form.form.reset();
  //  this.service.formData = new Student();

  //}
}
