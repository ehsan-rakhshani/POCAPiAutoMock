//using ApiDocumentation.Models.Entities;
////using ApiDocumentation.Models.Enums;
//using System;
//using System.Collections.Generic;

//namespace ApiDocumentation.Models.Infra.FakeDatas
//{
//    public static class FakeObject
//    {
//        public static Owner Owner = new Owner(Guid.NewGuid(), "Ehsan", "Rakhshani", "09365957533");
//        public static Business Business = new Business(Guid.NewGuid(), "CarSells", "This is What is", Owner);
//        public static Account Account = CreateTree("Root", 3);
//        public static List<Arcticle> Articles = CreateArticles();
//        public static Vouchers Voucher = CreateRandomVoucher();

//        private static Account CreateTree(string name, int depth)
//        {
//            if (depth == 0)
//                return null;

//            var id = Guid.NewGuid();
//            var child = CreateTree($"{name}-Child", depth - 1);
//            return new Account(id, name, NaturalityHelper.GetRandomNaturality(), $"Code-{id.ToString().Substring(0, 4)}", child);
//        }

//        private static List<Arcticle> CreateArticles()
//        {
//            return new List<Arcticle>
//            {
//                new Arcticle(Guid.NewGuid(), RandomAmount(), NaturalityHelper.GetRandomNaturality()),
//                new Arcticle(Guid.NewGuid(), RandomAmount(), NaturalityHelper.GetRandomNaturality()),
//                new Arcticle(Guid.NewGuid(), RandomAmount(), NaturalityHelper.GetRandomNaturality())
//            };
//        }

//        private static Vouchers CreateRandomVoucher()
//        {
//            var fiscalPeriod = new FiscalPeriod(Guid.NewGuid(), "2025-Q1",Business, DateTime.Now.AddMonths(-3), DateTime.Now,Account);

//            return new Vouchers(
//                Guid.NewGuid(),
//                "Sample Voucher",
//                $"VCH-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}",
//                fiscalPeriod,
//                Articles, 
//                VoucherType.Manual
//            );
//        }

//        private static long RandomAmount()
//        {
//            var random = new Random();
//            return random.Next(1000, 10000); 
//        }
//    }

//    public static class NaturalityHelper
//    {
//        private static Random _random = new Random();

//        // Method to get a random Naturality value
//        public static Naturality GetRandomNaturality()
//        {
//            Array values = Enum.GetValues(typeof(Naturality));
//            return (Naturality)values.GetValue(_random.Next(values.Length));
//        }
//    }
//}
