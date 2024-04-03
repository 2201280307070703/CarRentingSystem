namespace CarRentingSystem.Services.Mapping
{
    using AutoMapper;

    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Web.ViewModels.Car;
    using CarRentingSystem.Web.ViewModels.Category;
    using CarRentingSystem.Web.ViewModels.Dealer;

    public class CarRentingSystemProfile: Profile
    {
        public CarRentingSystemProfile()
        {
            this.CreateMap<BecomeDealerFormModel, Dealer>();

            this.CreateMap<Car, CarCardViewModel>();

            this.CreateMap<Category, CategoryViewModel>();

            this.CreateMap<AddCarFormModel, Car>();

            this.CreateMap<Car, CarDetailsViewModel>();

            this.CreateMap<Dealer, DealerDetailsViewModel>();
        }
    }
}
