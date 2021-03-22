import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Page } from "../shared/page.type";
import { City } from "./city.type";

@Injectable({
  providedIn: "root",
})
export class CityService {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = "api/v1/cities";
  }

  getCities(searchTerm: string): Observable<Page<City>> {
    return this.http.get<Page<City>>(`${this.baseUrl}?term=${searchTerm}`);
  }
}
