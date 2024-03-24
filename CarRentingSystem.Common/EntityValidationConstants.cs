namespace CarRentingSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Car
        {
            public const int MakeMinLength = 2;
            public const int MakeMaxLength = 15;

            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 15;

            public const int DescriptionMinLength = 2;
            public const int DescriptionMaxLength = 15;

            public const int ImageUrlMaxLength = 15;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
        }

        public static class Dealer
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 20;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
