namespace agid.production.planner.Requests;

public record AddProductionPlanRequest(int tahun, int mingguKe, int[] rencanaProduksiHarian);
