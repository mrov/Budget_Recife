import { Component, ElementRef, Input, SimpleChanges, ViewChild } from '@angular/core';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-source-chart',
  templateUrl: './source-chart.component.html',
  styleUrls: ['./source-chart.component.scss']
})
export class SourceChartComponent {
  @ViewChild('sourceChartContainer') chartContainer!: ElementRef;

  @Input()
  budgetBySource: [] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes["budgetBySource"]) {
      // Action to perform when 'data' input property changes
      this.mountChart()
      // Perform your desired action here
    }
  }

  mountChart() {
    let options: Highcharts.Options = {
      chart: {
        type: 'column',
      },
      title: {
        text: 'Resource budget by source',
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
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
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

    let sources: string[] = [];
    let totalValuesBySource: any[] = [];

    this.budgetBySource.forEach((source: any) => {
      sources.push(source.resourceSourceName);
      totalValuesBySource.push(source.totalSourceValue);
    });

    options = {
      ...options,
      ...{
        xAxis: { categories: sources },
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
