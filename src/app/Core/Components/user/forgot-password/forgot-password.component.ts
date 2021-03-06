import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Core/services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  formModel = {
    Email:''
  }
  constructor(public service: UserService, private toastr: ToastrService,private router:Router) { }

  ngOnInit() {
  }
  onSubmit(form: NgForm) {
    this.service.ForgotPassword(form.value).subscribe(
      (res: any) => {
        if (res.succeeded) {
         this.service.formModel.reset();
    }
},
err => {
  if (err.status == 400)
    this.toastr.error('User does Not Exist');
  else
    console.log(err);
}
)}
}