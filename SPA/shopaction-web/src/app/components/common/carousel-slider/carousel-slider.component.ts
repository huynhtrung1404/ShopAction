import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/Product';
import { ProductService } from 'src/app/shared/services/product/product.service';

@Component({
  selector: 'app-carousel-slider',
  templateUrl: './carousel-slider.component.html',
  styleUrls: ['./carousel-slider.component.css']
})
export class CarouselSliderComponent implements OnInit {

  products: Product[] = [];
  language: string = "8431d434-cf6e-4900-9efd-1c7a6b5c6651";
  productIds: Array<string> = [
    "030EFEF6-2D94-4DF2-A643-08D882DF6E0B",
    "A714610F-B8D5-4A53-A644-08D882DF6E0B",
    "85B467E9-C6DB-43C4-A645-08D882DF6E0B"
  ]
  constructor(
    public productService: ProductService
  ) { }

  ngOnInit(): void {
    this.productIds.forEach(productId => {
      this.productService
        .getProductById(productId, this.language)
        .subscribe(
          x=> this.products.push(x)
        );
    });
  }

}
