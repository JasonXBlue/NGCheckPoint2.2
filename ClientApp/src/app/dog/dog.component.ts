import { Component, OnInit } from "@angular/core";
import { IDog } from "../interfaces/idog";

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

  constructor() {}

  ngOnInit() {}
}
