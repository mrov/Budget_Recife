import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  private apiUrl = 'https://localhost:7254'; // Replace with your API URL

  constructor(private http: HttpClient) { }

  getBudgetByMonths(): Observable<any> {
    const url = `${this.apiUrl}/Api/Budget/Monthly`;
    return this.http.get<any>(url);
  }

  getBudgetByCategories(): Observable<any> {
    const url = `${this.apiUrl}/Api/Budget/ByCategories`;
    return this.http.get<any>(url);
  }

  getBudgetBySource(): Observable<any> {
    const url = `${this.apiUrl}/Api/Budget/BySource`;
    return this.http.get<any>(url);
  }
}
