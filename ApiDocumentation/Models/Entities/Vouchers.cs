using ApiDocumentation.Models.Enums;

namespace ApiDocumentation.Models.Entities;

public record Vouchers(Guid Id, string Name, string VoucherNo, FiscalPeriod FiscalPeriod, List<Arcticle> Article, VoucherType Type);
