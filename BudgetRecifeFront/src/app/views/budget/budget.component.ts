import { Component } from '@angular/core';
import { BudgetService } from './budget.service';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.scss']
})
export class BudgetComponent {
  budgetByMonth = [];

  constructor (private budgetService: BudgetService) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.budgetService.getBudgetByMonths().subscribe(
      (response: any) => {
        // Handle the response data here
        this.budgetByMonth = response;
        console.log(response);
      },
      (error: any) => {
        // Handle any errors
        console.error(error);
      }
    );
  }
}
