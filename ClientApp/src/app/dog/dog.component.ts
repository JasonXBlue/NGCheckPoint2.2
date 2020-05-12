import { Component, OnInit } from "@angular/core";
import { IDog } from "../interfaces/idog";
import { DogService } from "../services/dog.service";

@Component({
  selector: "app-dog",
  templateUrl: "./dog.component.html",
  styleUrls: ["./dog.component.css"],
})
export class DogComponent implements OnInit {
  dog: IDog = {
    name: "",
    breed: "",
    age: 1,
    kidFriendly: true,
  };

  dogs: IDog[] = [];

  constructor(private service: DogService) {}

  async ngOnInit() {
    this.dogs = await this.service.getDogs();
    console.log(this.dogs);
  }

  async save() {
    const newDog = await this.service.addDog(this.dog);
    this.dogs.push(newDog);
    console.log(newDog);
  }
}
