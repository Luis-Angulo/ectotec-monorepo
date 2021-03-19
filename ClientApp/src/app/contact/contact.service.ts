import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, of } from 'rxjs';
import { Contact } from './contact.type';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private baseUrl: string;

  constructor(private clientService: HttpClient ) { 
    this.baseUrl = "api/contacts";
  }

  // todo: replace with actual API call when backend is built
  postContact(contact: Contact): Observable<object> {
    console.log("contactService.postContact: ", contact);
    return of({message: "post success"});
    // return this.clientService.post(`${this.baseUrl}`, contact);
  }
}
