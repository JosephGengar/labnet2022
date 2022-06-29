import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { map } from 'rxjs/operators';
import { Shipper } from 'src/app/models/shipperView';
import { ApishippersService } from 'src/app/services/apishippers.service';

@Component({
  selector: 'app-dialogShipper',
  templateUrl: './dialogShipper.component.html',
  styleUrls: ['./dialogShipper.component.scss']
})
export class DialogShipperComponent implements OnInit {
  asyncVal = nameCheck(this.apiShipper);
  frm: FormGroup = this.fb.group({
    company: ['', [Validators.required, Validators.maxLength(25)], [this.asyncVal]],
    phone: ['', [Validators.required, Validators.maxLength(25)]],
  })

  constructor(public dialogREF : MatDialogRef<DialogShipperComponent>,
              public apiShipper: ApishippersService,
              private snackBar : MatSnackBar,
              private readonly fb : FormBuilder,
              @Inject(MAT_DIALOG_DATA) public shipperD : Shipper) { 
                if(this.shipperD != null){
                  const companyD = this.frm.get('company');
                  companyD?.setValue(this.shipperD.CompanyName);
                  const phoneD = this.frm.get('phone');
                  phoneD?.setValue(this.shipperD.PhoneNumber)                 
                }
  }

  ngOnInit(): void {
    if(this.shipperD != null){
      const companyEd = this.frm.get('company');
      companyEd?.removeAsyncValidators(this.asyncVal);
      companyEd?.updateValueAndValidity();
 
    }
  }
  close(){
    this.dialogREF.close();
  }
  clean(){
    const companyDom = this.frm.get('company');
    const phoneDom = this.frm.get('phone');
    if(companyDom || phoneDom){
        companyDom?.setValue('');
        phoneDom?.setValue('');
      }


  }
  addShipper(){
    const shipper : Shipper = {CompanyName: this.frm.get('company')?.value, PhoneNumber: this.frm.get('phone')?.value, ShipperID: 0 };
    this.apiShipper.InsertUpdateShipper(shipper).subscribe({
      next: (response) => {
        if(response.sucess == 1){
          this.close();
          this.snackBar.open(response.message, '', {duration: 3000});
        }
        else{
          alert('Ups! We have a Problem with the operation');
        }
      },
      error: (err) => {
        alert('Error!!! while adding the Shipper');
      }
    })
  }
  editShipper(){
    const shipper : Shipper = {CompanyName: this.frm.get('company')?.value, PhoneNumber: this.frm.get('phone')?.value, ShipperID: this.shipperD.ShipperID};
    this.apiShipper.InsertUpdateShipper(shipper).subscribe({
      next: (response) => {
        if(response.sucess == 1){
          this.close();
          this.snackBar.open(response.message, '', {duration: 3500})
        }
        else{
          alert('Ups! We have a Problem with the operation');
        }
      },
      error: (err) => {
        alert('Error!!! while updating the Shipper');
      }  
    })
  }


}
export function nameCheck(apiShipper: any): AsyncValidatorFn {
  return (control : AbstractControl) => {
  const shipper : Shipper = {CompanyName: control.value, PhoneNumber: "", ShipperID: 0};
  return apiShipper.validationName(shipper)
  .pipe(
    map(({sucess}) => (sucess == 1) ? {companyExists: true} : null)
  );
};
}
