import { Component, OnInit } from '@angular/core';
import { ClientService } from '../shared/client.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styles: []
})
export class ClientsComponent implements OnInit {
clientList;
  constructor(private service: ClientService,
    private router:Router) { }

  ngOnInit() {
    this.service.getClientList().then(res=>this.clientList = res);
  }

}
