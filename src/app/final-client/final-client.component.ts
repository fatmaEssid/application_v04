import { Component, OnInit } from '@angular/core';
import { FinalClientService } from '../shared/final-client.service';

import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-final-client',
  templateUrl: './final-client.component.html',
  styles: []
})
export class FinalClientComponent implements OnInit {

 
  constructor(private service:FinalClientService,
    private router:Router,
    public snackBar: MatSnackBar) { }


  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?:NgForm){
 
    if(form = null)
    this.resetForm(form);
    this.service.formData = {
      final_client_id:0,
      final_client_nom:'',
      final_client_adresse:'',
      final_client_contact:'',
      final_client_email:''
    };
  
  }
  onSubmit(form: NgForm){
   
    this.service.saveOrUpdateOrder().subscribe(res=> {
      this.resetForm();
      this.openSnackBar('FINAL CLIENT', 'Bien Enregistrée');
      this.router.navigate(['/final-clients']);
    });
    }
    openSnackBar(message: string, action: string) {
      this.snackBar.open(message, action, {
         duration: 4000,
         verticalPosition: 'top',
        
         
      });
   } 
  
}
