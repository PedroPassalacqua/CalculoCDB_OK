import { Component, OnInit } from '@angular/core';
import { CalculocdbService } from './services/calculocdb.service';
import { Observable } from 'rxjs';
import { FormGroup, FormControl, Validators, FormBuilder }  from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  public calculoForm:any=this.formBuilder.group({
    valorControl: [null,Validators.required],
    mesesControl: [null,Validators.required],
  }); 
  tabelaCalculo!: Observable<calculo[]>;
  showtabela!:any;
  meses!:any;
  valorinic!:any;

  ngOnInit():void{
    this.showtabela="";    
  } 
      
  constructor(private formBuilder: FormBuilder, private calculocdbService:CalculocdbService){}


  calcular():void{
    this.valorinic=this.calculoForm.get('valorControl')?.value
    if (this.valorinic)
    this.meses=this.calculoForm.get('mesesControl')?.value
    this.tabelaCalculo = this.calculocdbService.getcalculocdb(this.valorinic,this.meses);
    this.showtabela="mostra";
  }
}

export interface calculo{
  mes:number,
  valorBruto:number,
  valorLiquido:number  
}
