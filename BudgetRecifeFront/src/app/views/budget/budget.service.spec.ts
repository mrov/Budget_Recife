import { TestBed, inject } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { BudgetService } from './budget.service';
import {
  EconomicCategoryDTO,
  MonthlyValueDTO,
  ResourceSourceDTO,
} from 'src/app/utils/interfaces/Budget';

describe('BudgetService', () => {
  let service: BudgetService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BudgetService],
    });
    service = TestBed.inject(BudgetService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch budget by months', () => {
    const mockResponse: MonthlyValueDTO[] = [
      { month: 1, totalMonthValue: '100' },
      { month: 2, totalMonthValue: '200' },
    ];

    service.getBudgetByMonths().subscribe((response) => {
      expect(response).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(`${service.apiUrl}/Api/Budget/Monthly`);
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });

  it('should fetch budget by categories', () => {
    const mockResponse: EconomicCategoryDTO[] = [
      {
        economicCategoryCode: 1,
        economicCategoryName: 'Educacao',
        totalCategoryValue: 500,
      },
      {
        economicCategoryCode: 2,
        economicCategoryName: 'Saude',
        totalCategoryValue: 300,
      },
    ];

    service.getBudgetByCategories().subscribe((response) => {
      expect(response).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(`${service.apiUrl}/Api/Budget/ByCategories`);
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });

  it('should fetch budget by source', () => {
    const mockResponse: ResourceSourceDTO[] = [
      {
        resourceSourceCode: 1,
        resourceSourceName: 'Vigilancia Sanitaria',
        totalSourceValue: 3000,
      },
      {
        resourceSourceCode: 2,
        resourceSourceName: 'Turismo',
        totalSourceValue: 2000,
      },
    ];

    service.getBudgetBySource().subscribe((response) => {
      expect(response).toEqual(mockResponse);
    });

    const req = httpMock.expectOne(`${service.apiUrl}/Api/Budget/BySource`);
    expect(req.request.method).toBe('GET');
    req.flush(mockResponse);
  });
});
