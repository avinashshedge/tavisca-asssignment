import { Component, OnInit } from '@angular/core';
import { PizzaService } from './pizza-service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
})
export class MenuComponent implements OnInit {

    availablePizzas:any = [];

    constructor(private pizzaService:PizzaService){

    }

    ngOnInit(){
        this.getAllPizza()
    }
    
    getAllPizza(){
      this.pizzaService.getAllPizza().subscribe(res => {
        this.availablePizzas = res;
      })
    }
    
}
