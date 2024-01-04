using Bookify.Domain.Apartments.Entities;
using Bookify.Domain.Apartments.ValueObjects;
using Bookify.Domain.Bookings.ValueObjects;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange period)
    {
        var currency = apartment.Price.Currency;

        var pricePerPeriod = new Money(apartment.Price.Amount * period.LengthInDays, currency);

        var percentageUpCharge = 0m;
        foreach (var amentity in apartment.Amenities)
        {
            percentageUpCharge += amentity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning or Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var amenitiesUpCharge = Money.Zero(currency);
        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(pricePerPeriod.Amount * percentageUpCharge, currency);
        }

        var totalPrice = Money.Zero(currency);
        totalPrice += pricePerPeriod;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetails(pricePerPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}

public record PricingDetails(
    Money PricePerPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);