import {
  Component,
  ElementRef,
  Input,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import * as Highcharts from 'highcharts';

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
  budgetByMonth: [] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['budgetByMonth']) {
      // Action to perform when 'data' input property changes
      this.mountChart();
      // Perform your desired action here
    }
  }

  mountChart() {
    if (this.chartContainer) {
      let options: Highcharts.Options = {
        chart: {
          type: 'column',
        },
        title: {
          text: 'Monthly Resource Budget',
        },
        subtitle: {
          text: 'Source: http://dados.recife.pe.gov.br/dataset/despesas-orcamentarias',
        },
        xAxis: {},
        yAxis: {
          title: {
            text: 'Valor liquido total',
          },
        },
        tooltip: {
          headerFormat:
            '<span style="font-size:10px">{point.key}</span><table>',
          pointFormat:
            '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y:.2f}</b></td></tr>',
          footerFormat: '</table>',
          shared: true,
          useHTML: true,
        },
        plotOptions: {
          column: {
            pointPadding: 0.2,
            borderWidth: 0,
          },
        },
        series: [],
      };

      let months: string[] = [];
      let totalValuesByMonth: any[] = [];

      this.budgetByMonth.forEach((month: any) => {
        months.push(monthsMap[month.month]);
        totalValuesByMonth.push(month.totalMonthValue);
      });

      options = {
        ...options,
        ...{
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

      Highcharts.chart(this.chartContainer.nativeElement, options);
    }
  }
}
