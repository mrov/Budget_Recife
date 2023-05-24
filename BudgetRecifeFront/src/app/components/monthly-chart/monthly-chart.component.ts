import {
  Component,
  ElementRef,
  Input,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import * as Highcharts from 'highcharts';
import { options } from 'src/app/utils/constants/chart';
import { MonthlyValueDTO } from 'src/app/utils/interfaces/Budget';

const monthsMap: { [key: number]: string } = {
  1: 'Jan',
  2: 'Feb',
  3: 'Mar',
  4: 'Apr',
  5: 'May',
  6: 'Jun',
  7: 'Jul',
  8: 'Aug',
  9: 'Sep',
  10: 'Oct',
  11: 'Nov',
  12: 'Dec',
};

@Component({
  selector: 'app-monthly-chart',
  templateUrl: './monthly-chart.component.html',
  styleUrls: ['./monthly-chart.component.scss'],
})
export class MonthlyChartComponent {
  @ViewChild('monthlyChartContainer') chartContainer!: ElementRef;

  @Input()
  budgetByMonth: MonthlyValueDTO[] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['budgetByMonth']) {
      this.mountChart();
    }
  }

  mountChart() {
    if (this.chartContainer) {
      let months: string[] = [];
      let totalValuesByMonth: any[] = [];

      this.budgetByMonth.forEach((month: any) => {
        months.push(monthsMap[month.month]);
        totalValuesByMonth.push(month.totalMonthValue);
      });

      let formatedOptions: Highcharts.Options = {
        ...options,
        ...{
          title: {
            text: 'Monthly Resource Budget',
          },
          xAxis: { categories: months },
          series: [
            {
              name: 'Valor Liquido Total',
              type: 'column',
              data: totalValuesByMonth,
            },
          ],
        },
      };

      Highcharts.chart(this.chartContainer.nativeElement, formatedOptions);
    }
  }
}
