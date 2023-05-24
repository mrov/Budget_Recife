import { Component, ElementRef, ViewChild } from '@angular/core';
import { BudgetService } from './budget.service';
import { EconomicCategoryDTO, MonthlyValueDTO, ResourceSourceDTO } from 'src/app/utils/interfaces/Budget';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.scss'],
})
export class BudgetComponent {
  @ViewChild('chartContainer') chartContainer!: ElementRef;

  budgetByMonth: MonthlyValueDTO[] = [];
  budgetByCategory: EconomicCategoryDTO[] = [];
  budgetBySource: ResourceSourceDTO[] = [];

  constructor(private budgetService: BudgetService) {}

  async ngOnInit() {
    await this.getBudgetByMonths();
    await this.getBudgetByCategories();
    await this.getBudgetBySource();
  }

  getBudgetByMonths() {
    this.budgetService.getBudgetByMonths().subscribe(
      (response: MonthlyValueDTO[]) => {
        // Handle the response data here
        this.budgetByMonth = response;
      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }

  getBudgetByCategories() {
    this.budgetService.getBudgetByCategories().subscribe(
      (response: EconomicCategoryDTO[]) => {
        // Handle the response data here
        this.budgetByCategory = response;
      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }

  getBudgetBySource() {
    this.budgetService.getBudgetBySource().subscribe(
      (response: ResourceSourceDTO[]) => {
        // Handle the response data here
        this.budgetBySource = response;
      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }
}
