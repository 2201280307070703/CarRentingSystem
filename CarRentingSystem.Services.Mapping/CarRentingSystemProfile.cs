namespace CarRentingSystem.Services.Mapping
{
    using AutoMapper;

    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Web.ViewModels.Dealer;

    public class CarRentingSystemProfile: Profile
    {
        public CarRentingSystemProfile()
        {
            this.CreateMap<BecomeDealerFormModel, Dealer>();
        }
    }
}
