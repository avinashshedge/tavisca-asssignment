import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'sub-item',
  templateUrl: './sub-item.component.html',
})
export class SubItemComponent implements OnInit {

    selectedItems:any=[];
    @Input() header:string;
    @Input() data;
    @Input() defaultData;

    @Output() onItemClick = new EventEmitter<any>();
    availablePizzas:any = [];

    constructor(){

    }

    ngOnInit(){
    }
    isDefaultSelection(item){
        if(this.defaultData != null){
            let ingridients = this.defaultData.map(i => i.ingredientId);
            let index = ingridients.indexOf(item.id);
            if(index != -1){
                return true;
            }
        }
        return false;
    }

    onSelect(event,item){
        if(event.target.checked){
            this.selectedItems.push(item);
        }else{
            var index = this.selectedItems.findIndex(i => i.id == item.id);
            if (index > -1) {
                this.selectedItems.splice(index, 1);
            }
        }
        this.onItemClick.emit(this.selectedItems);
    }
}