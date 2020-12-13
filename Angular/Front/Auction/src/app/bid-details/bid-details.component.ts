import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { TokenService } from '../token.service';
import { ItemsService } from '../items.service';
import { Bid } from '../models/Bid';

@Component({
  selector: 'app-bid-details',
  templateUrl: './bid-details.component.html',
  styleUrls: ['./bid-details.component.css']
})
export class BidDetailsComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router:Router,private authService:AuthService, private tokenService:TokenService,private itemService:ItemsService) { }

  ngOnInit() {
    this.getBidById();
  }

  public bid:Bid;
  public getBidById():void
  {
    const id=+this.route.snapshot.paramMap.get('id');
    this.itemService.getHighestAmountForItem(id).subscribe(x=>this.bid=x, error=>this.router.navigate([`allItems`]));
  }
}
