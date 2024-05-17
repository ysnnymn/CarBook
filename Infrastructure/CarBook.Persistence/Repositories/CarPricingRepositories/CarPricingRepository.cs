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
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarsPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(e => e.PricingID == 2).ToList();
			return values;
		}
		public List<CarPricingViewModel> GetCarsPricingWithTimePeriod()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = @"
            SELECT *
            FROM 
            (
                SELECT 
                    Cars.Model,
                    Brands.Name AS BrandName,
                    Cars.CoverImageUrl,
                    CarPricings.PricingID,
                    CarPricings.Amount
                FROM CarPricings
                INNER JOIN Cars ON Cars.CarID = CarPricings.CarId
                INNER JOIN Brands ON Brands.BrandID = Cars.BrandID
            ) AS SourceTable
            PIVOT 
            (
                SUM(Amount) 
                FOR PricingID IN ([2], [3], [4])
            ) AS PivotTable;
        ";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["BrandName"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
					{
						reader.IsDBNull(reader.GetOrdinal("2")) ? 0 : Convert.ToDecimal(reader["2"]),
						reader.IsDBNull(reader.GetOrdinal("3")) ? 0 : Convert.ToDecimal(reader["3"]),
						reader.IsDBNull(reader.GetOrdinal("4")) ? 0 : Convert.ToDecimal(reader["4"])
					}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
			}
			return values;
		}


		//public List<CarPricingViewModel> GetCarsPricingWithTimePeriod()
		//{
		//	List<CarPricingViewModel> values = new List<CarPricingViewModel>();
		//	using (var command = _context.Database.GetDbConnection().CreateCommand())
		//	{
		//		command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
		//		command.CommandType = System.Data.CommandType.Text;
		//		_context.Database.OpenConnection();
		//		using (var reader = command.ExecuteReader())
		//		{
		//			while (reader.Read())
		//			{
		//				CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
		//				{
		//					Brand = reader["Name"].ToString(),
		//					Model = reader["Model"].ToString(),
		//					CoverImageUrl = reader["CoverImageUrl"].ToString(),
		//					Amounts = new List<decimal>
		//					{
		//						Convert.ToDecimal(reader["2"]),
		//						Convert.ToDecimal(reader["3"]),
		//						Convert.ToDecimal(reader["4"])
		//					}
		//				};
		//				values.Add(carPricingViewModel);
		//			}
		//		}
		//		_context.Database.CloseConnection();
		//		return values;
		//	}
		//}

	}
}
