import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PizzaService } from './pizza-service';

@Component({
  selector: 'detail-pizza',
  templateUrl: './detail-pizza.component.html',
})
export class DetailPizzaComponent implements OnInit {

    selectedPizzaId;
    selectedPizzaSize;selectedCrushType;selectedIngridients:any=[];
    selectedToppings:any=[];isExtraCheeseSelected =false;

    selectedPizza:any;extraCheeseItem:any;
    pizzaSizes:any=[];crushTypes:any=[];ingridients:any=[];toppings:any=[];

    constructor(private route:ActivatedRoute,private pizzaService:PizzaService,private router:Router){
        this.route.params.subscribe( params =>
            this.selectedPizzaId = params['id']
        );

        this.pizzaSizes.push(
            { id:1, name:'Small',price:80 },
            { id:2, name:'Regular',price:100 },
            { id:3, name:'Large',price:120 },
        );

        this.crushTypes.push(
            { id:1, name:'Thin',price:100 },
            { id:2, name:'Hand',price:80 },
            { id:3, name:'Pan',price:60 },
        );
    }


    ngOnInit(){
        this.getPizzaIngredients();
        this.getSelectedPizza();
    }

    getSelectedPizza(){
        this.pizzaService.getPizzaById(this.selectedPizzaId).subscribe(res=>{
            let result:any = res;
            this.selectedPizza = result.pizza;
            this.selectedPizza.pizzaSize = result.itemTypes.filter(i=>i.type == 1)[0];
            this.selectedPizza.crushType = result.itemTypes.filter(i=>i.type == 2)[0]; 
            this.selectedPizza.defaultIngridient = result.defaultIngridient;
            this.selectedPizzaSize = this.selectedPizza.pizzaSize.id;
            this.selectedCrushType = this.selectedPizza.crushType.id;
            this.updateBaseTotal();
        });
        
    }

    getPizzaIngredients(){
        this.pizzaService.getPizzaIngredients().subscribe(res=>{
            if(res != null){
                let result :any = res;
                this.extraCheeseItem = result.filter(i => i.type == 1)[0];        
                this.ingridients  = result.filter(i => i.type == 2);        
                this.toppings = result.filter(i => i.type == 3);
            }
        });
    }
    

    onSelectCrushType(event, newValue) {
        this.selectedCrushType = newValue.id;
        this.selectedPizza.crushType = newValue; 
        this.updateBaseTotal();
    }

    onSelectPizzaSize(event, newValue) {
        this.selectedPizzaSize = newValue.id;
        this.selectedPizza.pizzaSize = newValue; 
        this.updateBaseTotal();
    }

    onExtraCheese(event){
            this.isExtraCheeseSelected = event.target.checked; 
            this.updateBaseTotal();
    }

    onIngridientSelect(event,item){
        if(event.target.checked){
            this.selectedIngridients.push(item);
        }else{
            var index = this.selectedIngridients.findIndex(i => i.id == item.id);
            if (index > -1) {
                this.selectedIngridients.splice(index, 1);
            }
        }
    }

    onToppingsSelect(event,item){
        if(event.target.checked){
            this.selectedToppings.push(item);
        }else{
            var index = this.selectedToppings.findIndex(i => i.id == item.id);
            if (index > -1) {
                this.selectedToppings.splice(index, 1);
            }
        }
    }

    updateBaseTotal(){
        debugger;
        this.selectedPizza.baseprice = this.selectedPizza.crushType.price + this.selectedPizza.pizzaSize.price;
        if(this.isExtraCheeseSelected){
            this.selectedPizza.baseprice += this.extraCheeseItem.price;
        }

        if(this.selectedPizza.defaultIngridient != null && this.selectedPizza.defaultIngridient.length > 0){
            let filterIngridient = this.ingridients
                                        .filter(i => this.selectedPizza.defaultIngridient.map(o =>o.ingredientId)
                                        .includes(i.id));
            if(filterIngridient.length > 0){
                let ingridientsTotal = filterIngridient.map(i => i.price).reduce((acc,item) => { return acc + item});
                this.selectedPizza.baseprice += ingridientsTotal;
            }
        }

        if(this.selectedIngridients != null && this.selectedIngridients.length > 0){
            let filterIngridient = this.selectedIngridients
                                        .filter(i => !this.selectedPizza.defaultIngridient.map(o =>o.ingredientId)
                                        .includes(i.id));
            if(filterIngridient.length > 0){
                let ingridientsTotal = filterIngridient.map(i => i.price).reduce((acc,item) => { return acc + item});
                this.selectedPizza.baseprice += ingridientsTotal;
            }
        }

        if(this.selectedToppings != null && this.selectedToppings.length > 0){
            let ingridientsTotal = this.selectedToppings.map(i => i.price).reduce((acc,item) => { return acc + item});
            this.selectedPizza.baseprice += ingridientsTotal;
        }
    }

    updateTotalOnIngridient(selectedItems){
        this.selectedIngridients = selectedItems;
        this.updateBaseTotal();
    }

    updateTotalOnToppings(selectedItems){
        this.selectedToppings = selectedItems;
        this.updateBaseTotal();
    }

    onAdd(){
        this.selectedPizza.defaultIngridient = [this.selectedIngridients,this.selectedToppings];
        this.pizzaService.addPizza(this.selectedPizza).subscribe(res=>{
            alert("Your order is successfully created. Order No: " + res);
            this.router.navigate(['/']);
        });
    }
}
