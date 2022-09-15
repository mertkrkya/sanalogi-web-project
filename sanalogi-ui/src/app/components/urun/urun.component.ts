import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SiparisModel } from 'src/app/models/siparis';
import { SiparisService } from 'src/app/services/siparis.service';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-urun',
  templateUrl: './urun.component.html',
  styleUrls: ['./urun.component.scss']
})
export class UrunComponent implements OnInit {

  siparisler:SiparisModel[] = [];
  @Output() urunEvent:EventEmitter<any> = new EventEmitter();
  mySubscription: Subscription
  constructor(
    private siparisService:SiparisService,
    private toastrService:ToastrService
  ) {    this.mySubscription= interval(3000).subscribe((x =>{
    this.getAll();
}));}

  ngOnInit(): void {
    this.getAll()
  }
  getAll(){
    this.siparisService.getAll().subscribe(res =>{
      if(res.isSuccess)
      {
        this.siparisler = res.data;
      }
    })
  }

  deleteItem(item:number){
    this.siparisService.delete(item).subscribe(res => {
      if(res.isSuccess)
      {
        this.toastrService.info("Ürün başarıyla silindi.");
        this.getAll();
      }
    })
  }

  updateItem(item:SiparisModel){
    console.log(item)
    this.urunEvent.emit({data : item});
  }
}
