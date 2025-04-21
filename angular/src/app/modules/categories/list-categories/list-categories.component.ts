import { Component } from '@angular/core';
import { PagedAndSortedResultRequestDto } from '@abp/ng.core';
import { CategoryDto } from '@proxy/categories/dtos';
import { CategoriesService } from '@proxy/categories';

@Component({
  selector: 'app-list-categories',
  standalone:true,
  imports: [],
  templateUrl: './list-categories.component.html',
  styleUrl: './list-categories.component.scss'
})
export class ListCategoriesComponent {
  categories: CategoryDto[] = [];
  input: PagedAndSortedResultRequestDto = { maxResultCount: 10, skipCount: 0 };

  constructor(private categoriesService: CategoriesService) {
  }
  ngOnInit(): void {
    this.categoriesService.getList(this.input).subscribe(result => this.categories = result.items);
  }
}
