import { Component, OnInit } from '@angular/core';
import { StudentService } from '../shared/student-service';
import { Student } from '../shared/student-model';
import { FetchStudentsComponent } from './fetch-students.component';
@Component({
  selector: 'fetch-students-view',
  templateUrl: './fetch-students-view.component.html',
  styles: [
  ]
})
export class FetchStudentsViewComponent implements OnInit {

  constructor(public service: StudentService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: Student) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: string) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteStudent(id)
        .subscribe(
          res => {
            this.service.refreshList();
          },
          err => { console.log(err) }
        )
    }
  }

}
