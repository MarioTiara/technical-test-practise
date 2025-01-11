namespace Production.Planner.Dtos;

public record ProductPlanView(int tahun, string mingguKe,
int[] Senin, 
int[] Selasa, 
int[] Rabu, 
int[] Kamis, 
int[] Jumat, 
int[] Sabtu, 
int[] Minggu);