namespace ApiDocumentation.Models.Entities;

public record FiscalPeriod(Guid Id, string Name, Business MyBusiness, DateTime From, DateTime To,Account Account);