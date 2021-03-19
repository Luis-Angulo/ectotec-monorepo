import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactRoutingModule } from './contact-routing.module';
import { ContactFormComponent } from './contact-form/contact-form.component';

import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [ContactFormComponent],
  imports: [
    CommonModule,
    ContactRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class ContactModule { }
