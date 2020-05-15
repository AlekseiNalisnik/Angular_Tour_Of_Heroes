import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  text: string;

  private querySubscription: Subscription;

  constructor(private route: ActivatedRoute){
      // this.routeSubscription = route.params.subscribe(params=> {
      //   this.id=params['id'];
      // });
      this.querySubscription = route.queryParams.subscribe(
          (queryParam: any) => {
              this.text = queryParam['text'];
              console.log('TEXT FROM HEADER - ', this.text);
          }
      );
  }

  ngOnInit() {}

}
