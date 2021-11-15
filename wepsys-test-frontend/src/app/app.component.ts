import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public listOfUsers: any[] = [];
  public isRepeatedEmail = false;
  public isSubmited = false;
  public userForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', Validators.required, Validators.email],
    phone: ['', Validators.required],
  });

  constructor(private fb: FormBuilder) { }

  onSubmit() {
    this.isRepeatedEmail = false;
    this.isSubmited = true;
    console.log(this.userForm.value, this.userForm.valid);
    if (this.userForm.valid) {
      var idx = this.getIndexOfUser(this.userForm.value.email);
      console.log(idx);
      if (idx < 0) {
        var form = this.userForm.value;
        this.listOfUsers.push({
          firstName: form.firstName,
          lastName: form.lastName,
          email: form.email,
          phone: form.phone
        })
      } else {
        this.isRepeatedEmail = true;
      }
    }
  }

  removeUser(user: any) {
    var idx = this.getIndexOfUser(user.email);
    if (idx >= 0) {
      this.listOfUsers.splice(idx, 1);
    }
  }

  private getIndexOfUser(email: string): number {
    return this.listOfUsers.indexOf((u: any) => u.email === email);
  }
}
