import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BudgetComponent } from './views/budget/budget.component';
import { HttpClientModule } from '@angular/common/http';

// Material imports
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';

// Components
import { MonthlyChartComponent } from './components/monthly-chart/monthly-chart.component';
import { CategoriesChartComponent } from './components/categories-chart/categories-chart.component';
import { SourceChartComponent } from './components/source-chart/source-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    BudgetComponent,
    MonthlyChartComponent,
    CategoriesChartComponent,
    SourceChartComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatCardModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
