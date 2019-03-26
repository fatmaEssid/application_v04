import { Component, OnInit } from '@angular/core';
import { ContratService } from '../shared/contrat.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contrats',
  templateUrl: './contrats.component.html',
  styles: []
})
export class ContratsComponent implements OnInit {
  contratList;
  constructor(private service: ContratService,
    private router:Router) { }

  ngOnInit() {
    this.service.getContratList().then(res=>this.contratList = res);
  }
}
