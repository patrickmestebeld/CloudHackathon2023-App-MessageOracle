﻿using Bogus;

namespace MessageOracle.Infra.Personal.Fakers
{
    public static class GeneratorConstants
    {
        public static bool IsRealistic = false;
        public static string FakeLocal => IsRealistic ? "nl" : "ne";
        private static void SetSeed() => Randomizer.Seed = new Random(123456789);
        private static void SetClock()
        {
            Bogus.DataSets.Date.SystemClock = () => DateTime.Parse("6/6/2021 2:00PM");
        }

        public static void SettleFakeDataSets()
        {
            SetSeed();
            SetClock();
        }
    }
}
