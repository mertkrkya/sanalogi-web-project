import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SiparisModel } from 'src/app/models/siparis';
import { SiparisService } from 'src/app/services/siparis.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-siparis',
  templateUrl: './siparis.component.html',
  styleUrls: ['./siparis.component.scss']
})
export class SiparisComponent implements OnInit {

  addForm:FormGroup;
  @Input() siparis:SiparisModel;
  constructor(
    private siparisService:SiparisService,
    private toastrService:ToastrService
    ) { this.createAddForm()}
  ngOnInit(): void {
  }

  createAddForm(){
    this.addForm = new FormGroup({
      'id': new FormControl(0),
      'UrunAdi': new FormControl(null,[Validators.required]),
      'Adet': new FormControl(null,[Validators.required,Validators.min(1)]),
      'Tutar': new FormControl(null,[Validators.required,Validators.min(1)]),
      'SiparisVerenFirma': new FormControl(null,[Validators.required]),
      'SiparisTarihi': new FormControl(null,[Validators.required])
    })
  }
  siparisKaydet(){
    console.log(this.addForm)
    if(this.addForm.valid)
    {
      let model:SiparisModel = this.addForm.value;
      console.log(model)
      if(model.id == 0)
      {
        this.siparisService.add(model).subscribe((res) =>{
          if(res.isSuccess)
          {
            this.addForm.reset();
            this.toastrService.success("Sipariş başarılı bir şekilde oluşturulmuştur.");
            this.createAddForm();
          }
          else{
            console.log(res)
          }
        })
      }
      else
      {
        this.siparisService.update(model).subscribe((res) =>{
          if(res.isSuccess)
          {
            this.addForm.reset();
            this.toastrService.success("Sipariş başarılı bir şekilde güncellenmiştir.");
            this.createAddForm();
          }
          else{
            Swal.fire("Hata","Sunucudan hata geldi.","error")
          }
        })
      }
    }
    else{
      Swal.fire("Hata","Validasyon hatası.","error")
    }
  }
}
