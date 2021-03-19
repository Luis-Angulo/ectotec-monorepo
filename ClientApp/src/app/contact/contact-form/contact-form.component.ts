import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ContactService } from "../contact.service";

@Component({
  selector: "app-contact-form",
  templateUrl: "./contact-form.component.html",
  styleUrls: ["./contact-form.component.css"],
})
export class ContactFormComponent implements OnInit {
  private form: FormGroup;
  constructor(
    private fb: FormBuilder,
    private contactService: ContactService
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      nombre: ["", Validators.required],
      email: ["", Validators.required],
      telefono: ["", Validators.required],
      fecha: [Date.now, Validators.required],
      ciudad: ["", Validators.required],
    });
  }

  submit() {
    if (this.form.valid){
      this.contactService.postContact(this.form.value);
    } else {
      // TODO: import toastr and add confirmation and errors here
      console.log("invalid form state");
    }
    
  }
}
