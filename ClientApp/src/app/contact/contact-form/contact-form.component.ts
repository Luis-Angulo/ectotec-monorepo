import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { debounceTime, skipWhile, switchMap } from "rxjs/operators";
import { Page } from "src/app/shared/page.type";
import { PageRequest } from "src/app/shared/pageRequest.type";
import { CityService } from "../city.service";
import { City } from "../city.type";

import { ContactService } from "../contact.service";

@Component({
  selector: "app-contact-form",
  templateUrl: "./contact-form.component.html",
  styleUrls: ["./contact-form.component.css"],
})
export class ContactFormComponent implements OnInit {
  private form: FormGroup;
  page: Page<City>;
  wait = 500;
  minLength = 3;
  selectedCity: City;

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    private cityService: CityService
  ) {}

  ngOnInit() {
    const pr: PageRequest = { searchTerm: "" };
    this.form = this.buildForm(pr);
    this.fetchCities(pr.searchTerm).subscribe((page) => {
      
      this.page = page;
    });
  }

  buildForm(pr: PageRequest): FormGroup {
    const form = this.fb.group({
      name: ["", Validators.required],
      email: ["", Validators.required],
      phone: ["", Validators.required],
      date: ["", Validators.required],
      city: ["", Validators.required],
    });

    form
      .get("city")
      .valueChanges.pipe(
        skipWhile(
          (userInputString: string) => userInputString.length >= this.minLength
        ),
        debounceTime(this.wait),
        switchMap((searchTerm: string) => this.fetchCities(searchTerm))
      )
      .subscribe((page: Page<City>) => {
        this.page = page;

        this.selectedCity = page.items[0] || this.selectedCity;
        console.log(this.selectedCity);
        console.log(this.page);
      });

    return form;
  }

  private fetchCities(searchTerm: string) {
    return this.cityService.getCities(searchTerm);
  }

  submit() {
    let formdata = this.form.value;
    formdata.cityId = this.selectedCity.cityId;
    formdata.city = null;
    if (this.form.valid) {      
      console.log(formdata);
      this.contactService.postContact(formdata).subscribe(e => console.log(e));
    } else {
      alert("form is invalid");
    }
  }
}
