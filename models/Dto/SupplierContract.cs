namespace Biblioteca_API.models.Dto;

public record SupplierContract(int id, bool contractStatus, DateTime? contractStart, DateTime? contractEnd);