import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../categories.service';
import { TokenService } from '../token.service';
import { AuthService } from '../auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {
  public Name:string;
  constructor(private route: ActivatedRoute, private router:Router,private authService:AuthService, private tokenService:TokenService, private categoryService:CategoriesService) { }

  ngOnInit() {
  }

  public addCategory()
  {
   
    this.categoryService.createCategory({Id:0,   Name:this.Name}).subscribe(_ => {
      this.router.navigate([`categories`]); alert("Успішно додано")
    }, (error) => {alert("Не вдалося додати");  this.router.navigate([`categories`]); });
  }

}
