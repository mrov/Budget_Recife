import {
  Component,
  ElementRef,
  Input,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import * as Highcharts from 'highcharts';

import { options } from '../../utils/constants/chart';

@Component({
  selector: 'app-categories-chart',
  templateUrl: './categories-chart.component.html',
  styleUrls: ['./categories-chart.component.scss'],
})
export class CategoriesChartComponent {
  @ViewChild('categoriesChartContainer') chartContainer!: ElementRef;

  @Input()
  budgetByCategory: [] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['budgetByCategory']) {
      this.mountChart();
    }
  }

  mountChart() {
    if (this.chartContainer) {
      let categories: string[] = [];
      let totalValuesBySource: any[] = [];

      this.budgetByCategory.forEach((source: any) => {
        categories.push(source.economicCategoryName);
        totalValuesBySource.push(source.totalCategoryValue);
      });

      let formatedOptions: Highcharts.Options = {
        ...options,
        ...{
          title: {
            text: 'Resource budget by category',
          },
          xAxis: { categories: categories },
          series: [
            {
              name: 'Valor Liquido Somados',
              type: 'column',
              data: totalValuesBySource,
            },
          ],
        },
      };

      Highcharts.chart(this.chartContainer.nativeElement, formatedOptions);
    }
  }
}
