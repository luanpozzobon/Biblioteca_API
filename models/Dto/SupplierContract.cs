namespace Biblioteca_API.models.Dto;

public record SupplierContract(int id, DateTime? contractStart, DateTime? contractEnd, bool contractStatus);