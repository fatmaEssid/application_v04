import { ClientDetail } from 'src/app/shared/client-detail.model';
import { FinalClient } from 'src/app/shared/final-client.model';
import { FinalClientService } from 'src/app/shared/final-client.service';
import { ClientService } from 'src/app/shared/client.service';
import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styles: []
})
export class ClientDetailsComponent implements OnInit {

  formData : ClientDetail;
  finalClientList :FinalClient[];
  isValid: boolean = true;
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public data ,
    public dialogRef: MatDialogRef<ClientDetailsComponent>,
    private finalClientService: FinalClientService,
    private clientService: ClientService) { }








  ngOnInit() {
this.finalClientService.getFinalClientList().then(res => this.finalClientList = res as FinalClient[]);
    if (this.data.clientDetailIndex == null)
    this.formData = {
      client_detail_id:null,
      client_mediator:true,
      client_id:this.data.client_id,
      final_client_id:0,
      final_client_nom:''
      }  
    else
      this.formData = Object.assign({}, this.clientService.clientDetails[this.data.clientDetailIndex]);
 
}
  updateName(ctrl) {
    if (ctrl.selectedIndex == 0) {
     
      this.formData.final_client_nom = '';
    }
    else {
      
      this.formData.final_client_nom = this.finalClientList[ctrl.selectedIndex - 1].final_client_nom;
    }
    
  }

   onSubmit(form: NgForm) {
    if (this.validateForm(form.value)) {
      if (this.data.clientDetailIndex == null)
        this.clientService.clientDetails.push(form.value);
      else
        this.clientService.clientDetails[this.data.clientDetailIndex] = form.value;
      this.dialogRef.close();
    }
  }

  validateForm(formData: ClientDetail) {
    this.isValid = true;
    if (formData.final_client_id == 0)
      this.isValid = false;
    return this.isValid;
  }





}//fin de la classe ClientDetailsComponent