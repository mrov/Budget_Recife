interface EconomicCategoryDTO {
    economicCategoryCode: number;
    economicCategoryName: string;
    totalCategoryValue: number;
}

interface MonthlyValueDTO {
    month: number;
    totalMonthValue: string;
}

interface ResourceSourceDTO {
    resourceSourceCode: number;
    resourceSourceName: string;
    totalSourceValue: number;
}

export { EconomicCategoryDTO, MonthlyValueDTO, ResourceSourceDTO }