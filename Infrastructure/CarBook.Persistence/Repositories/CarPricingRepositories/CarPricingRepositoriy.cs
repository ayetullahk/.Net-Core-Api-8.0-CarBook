using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepositoriy : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepositoriy(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWhithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).ToList();
            return values;
        }

        public List<CarPricingViewModel> GetCarPricingWhithTimePeriod()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricing Inner Join Cars on Cars.CarPricings.CarId Inner Join Brands on Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID in ([2],[3],[4])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader()) 
                { 
                    while (reader.Read()) 
                    {
                        CarPricingViewModel viewModel = new CarPricingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            Brand = reader["Name"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts=new List<decimal>
                            {
                                Convert.ToDecimal(reader["2"]),
                                Convert.ToDecimal(reader["3"]),
                                Convert.ToDecimal(reader["4"])
                            }
                        };
                        values.Add(viewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}
