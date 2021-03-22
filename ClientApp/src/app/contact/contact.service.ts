import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { Contact } from "./contact.type";

@Injectable({
  providedIn: "root",
})
export class ContactService {
  private baseUrl: string;

  constructor(private clientService: HttpClient) {
    this.baseUrl = "api/v1/contacts";
  }

  postContact(contact: Contact): Observable<object> {
    return this.clientService.post(`${this.baseUrl}`, contact);
  }
}
