import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BudgetComponent } from './budget.component';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';

// Components
import { MonthlyChartComponent } from '../../components/monthly-chart/monthly-chart.component';
import { CategoriesChartComponent } from '../../components/categories-chart/categories-chart.component';
import { SourceChartComponent } from '../../components/source-chart/source-chart.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';

describe('BudgetComponent', () => {
  let component: BudgetComponent;
  let fixture: ComponentFixture<BudgetComponent>;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        MatToolbarModule,
        MatIconModule,
        MatCardModule
      ],
      declarations: [BudgetComponent, MonthlyChartComponent,
        CategoriesChartComponent,
        SourceChartComponent],
    });
    fixture = TestBed.createComponent(BudgetComponent);
    httpMock = TestBed.inject(HttpTestingController);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
