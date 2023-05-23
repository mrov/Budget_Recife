import { Component, ElementRef, ViewChild } from '@angular/core';
import { BudgetService } from './budget.service';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.scss'],
})
export class BudgetComponent {
  @ViewChild('chartContainer') chartContainer!: ElementRef;

  budgetByMonth: [] = [];
  budgetByCategory: [] = [];
  budgetBySource: [] = [];

  constructor(private budgetService: BudgetService) {}

  async ngOnInit() {
    await this.getBudgetByMonths();
    await this.getBudgetByCategories();
    await this.getBudgetBySource();
  }

  getBudgetByMonths() {
    this.budgetService.getBudgetByMonths().subscribe(
      (response: any) => {
        // Handle the response data here
        this.budgetByMonth = response;
        console.log(this.budgetByMonth);
      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }

  getBudgetByCategories() {
    this.budgetService.getBudgetByCategories().subscribe(
      (response: any) => {
        // Handle the response data here
        this.budgetByCategory = response;
        console.log(this.budgetByCategory);

      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }

  getBudgetBySource() {
    this.budgetService.getBudgetBySource().subscribe(
      (response: any) => {
        // Handle the response data here
        this.budgetBySource = response;
        console.log(this.budgetBySource);

      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }
}
