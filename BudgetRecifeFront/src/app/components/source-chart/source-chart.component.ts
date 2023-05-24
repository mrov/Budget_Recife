import {
  Component,
  ElementRef,
  Input,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import * as Highcharts from 'highcharts';
import { options } from 'src/app/utils/constants/chart';
import { ResourceSourceDTO } from 'src/app/utils/interfaces/Budget';

@Component({
  selector: 'app-source-chart',
  templateUrl: './source-chart.component.html',
  styleUrls: ['./source-chart.component.scss'],
})
export class SourceChartComponent {
  @ViewChild('sourceChartContainer') chartContainer!: ElementRef;

  @Input()
  budgetBySource: ResourceSourceDTO[] = [];

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['budgetBySource']) {
      this.mountChart();
    }
  }

  mountChart() {
    if (this.chartContainer) {
      let sources: string[] = [];
      let totalValuesBySource: any[] = [];

      this.budgetBySource.forEach((source: any) => {
        sources.push(source.resourceSourceName);
        totalValuesBySource.push(source.totalSourceValue);
      });

      let formatedOptions: Highcharts.Options = {
        ...options,
        ...{
          title: {
            text: 'Resource budget by source',
          },
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

      Highcharts.chart(this.chartContainer.nativeElement, formatedOptions);
    }
  }
}
