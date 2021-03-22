import { City } from "./city.type";

export interface Contact {
  contactId?: number;
  name: string;
  email: string;
  phone: string;
  date: Date;
  city?: City;
  cityId: number;
}
