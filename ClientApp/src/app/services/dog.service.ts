import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IDog } from "../interfaces/idog";

@Injectable({
  providedIn: "root",
})
export class DogService {
  constructor(
    private httpClient: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  async getDogs() {
    // return this.httpClient.get<IDog[]>("${this.baseUrl}doglist").toPromise();
    return this.httpClient.get<IDog[]>(this.baseUrl + "doglist").toPromise();
  }

  async addDog(dog: IDog) {
    // return await this.httpClient
    //   .post<IDog>("${this.baseUrl}doglist", dog)
    //   .toPromise();
    return await this.httpClient
      .post<IDog>(this.baseUrl + "doglist", dog)
      .toPromise();
  }
}
