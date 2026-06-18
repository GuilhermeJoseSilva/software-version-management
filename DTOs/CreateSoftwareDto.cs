using System.ComponentModel.DataAnnotations;

namespace SoftwareManagement.DTOs;

public record CreateSoftwareDto(
    [Required][MaxLength(150)] string Nome,
    [Required][MaxLength(150)] string Fornecedor
);

public record SoftwareResponseDto(
    int Id,
    string Nome,
    string Fornecedor,
    DateTime DataCriacao
);

public record CreateVersaoDto(
    [Required] int SoftwareId,
    [Required][MaxLength(100)] string Descricao,
    [Required] DateTime DataRelease,
    [Required] bool Depreciado
);

public record VersaoResponseDto(
    int IdVersao,
    int SoftwareId,
    string Descricao,
    DateTime DataRelease,
    bool Depreciado
);