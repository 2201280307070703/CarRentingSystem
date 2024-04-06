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

            this.CreateMap<CarFormModel, Car>();

            this.CreateMap<Car, CarFormModel>();

            this.CreateMap<Car, CarDetailsViewModel>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name));

            this.CreateMap<Dealer, DealerDetailsViewModel>();
        }
    }
}
