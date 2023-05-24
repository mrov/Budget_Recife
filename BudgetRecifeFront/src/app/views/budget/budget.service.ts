import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EconomicCategoryDTO, MonthlyValueDTO, ResourceSourceDTO } from 'src/app/utils/interfaces/Budget';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  public apiUrl = 'https://localhost:7254'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getBudgetByMonths(): Observable<MonthlyValueDTO[]> {
    const url = `${this.apiUrl}/Api/Budget/Monthly`;
    return this.http.get<MonthlyValueDTO[]>(url);
  }

  getBudgetByCategories(): Observable<EconomicCategoryDTO[]> {
    const url = `${this.apiUrl}/Api/Budget/ByCategories`;
    return this.http.get<EconomicCategoryDTO[]>(url);
  }

  getBudgetBySource(): Observable<ResourceSourceDTO[]> {
    const url = `${this.apiUrl}/Api/Budget/BySource`;
    return this.http.get<ResourceSourceDTO[]>(url);
  }
}
