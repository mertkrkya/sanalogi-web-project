import { Component, Input, OnInit } from '@angular/core';
import { SiparisModel } from 'src/app/models/siparis';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  siparis:SiparisModel;
  siparisler:SiparisModel[];
  constructor() { }

  ngOnInit(): void {
  }

  getData(event:any){
    this.siparis = event.data;
    this.siparisler = event.siparisler;
  }
}
