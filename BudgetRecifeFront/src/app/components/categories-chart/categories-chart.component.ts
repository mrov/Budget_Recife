import {
  Component,
  ElementRef,
  Input,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import * as Highcharts from 'highcharts';

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
      let options: Highcharts.Options = {
        chart: {
          type: 'column',
        },
        title: {
          text: 'Resource budget by category',
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

      let categories: string[] = [];
      let totalValuesBySource: any[] = [];

      this.budgetByCategory.forEach((source: any) => {
        categories.push(source.economicCategoryName);
        totalValuesBySource.push(source.totalCategoryValue);
      });

      options = {
        ...options,
        ...{
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

      Highcharts.chart(this.chartContainer.nativeElement, options);
    }
  }
}
