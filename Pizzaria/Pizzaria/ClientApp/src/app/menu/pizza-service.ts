import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class PizzaService {
  public baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {
  }

  
  getAllPizza(){
    let url = this.baseUrl + '/pizza';
    return this.http.get(url);
  }

  getPizzaById(id){
    let url = this.baseUrl + '/pizza/'+ id;
    return this.http.get(url);
  }

  getPizzaIngredients(){
    let url = this.baseUrl + '/pizza/pizza-ingredients';
    return this.http.get(url);
  }

  addPizza(data){
    let url = this.baseUrl + '/pizza';
    return this.http.post(url,data);
  }


}