import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'clever';
  products: any[];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getProducts().subscribe(
      (products: Product[]) => {
        console.log(products);
        this.products = products;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
