using ApiDocumentation.Models.Enums;

namespace ApiDocumentation.Models.Entities;

public record Account(Guid Id, string Name, Naturality Naturality, string Code,Account child);