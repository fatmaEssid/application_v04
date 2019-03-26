import { Component, OnInit } from '@angular/core';
import { FinalClientService } from 'src/app/shared/final-client.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-final-clients',
  templateUrl: './final-clients.component.html',
  styles: []
})
export class FinalClientsComponent implements OnInit {

  finalClientList;
  constructor(private service: FinalClientService,
    private router:Router) { }

  ngOnInit() {
    this.service.getFinalClientList().then(res=>this.finalClientList = res);
  }

}
