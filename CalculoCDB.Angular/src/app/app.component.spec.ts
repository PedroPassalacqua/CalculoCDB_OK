import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Component} from '@angular/core';
import { CalculocdbService } from './services/calculocdb.service';

describe('AppComponent', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule,Component],
    providers: [CalculocdbService],
    declarations: [AppComponent,CalculocdbService]
  }));
  
  it('should app be created', () => {
    expect(AppComponent).toBeTruthy()
  })
});
