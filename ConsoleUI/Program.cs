using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
  public  class Program
    {
        static CarManager carManager;
        static BrandManager brandManager;
        static ColorManager colorManager;
        static CustomerManager customerManager;
        static RentalManager rentalManager;
        static UserManager userManager;

      public  static void Main(string[] args)
        {
        

            carManager = new CarManager(new EfCarDal());
            brandManager = new BrandManager(new EfBrandDal());
            colorManager = new ColorManager(new EfColorDal());
            customerManager = new CustomerManager(new EfCustomerDal());
            rentalManager = new RentalManager(new EfRentalDal());
            userManager = new UserManager(new EfUserDal());

            //Test();
            //carManagerTest();
            //brandManagerTest();
            //colorManagerTest();
            //DetailsTest();
            // ResultTest();

            Console.ReadLine();
        }

        private static void ResultTest()
        {
            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.BrandName + "\t" + car.Model);
                   
                }
            }
        }

        private static void DetailsTest()
        {
            Console.WriteLine("Car Name" + "\t" + "Brand Name" + "\t" + "Color Name" + "\t" + "Daily Price");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.Model + "\t" + car.BrandName + "\t" + car.ColorName + "\t" + car.DailyPrice);
            }
        }

        private static void carManagerTest()
        {
            //carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 650, Description = "Deneme 2", ModelYear = "2022" });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(brandManager.GetById(car.BrandId).Data);
            }
            //carManager.Delete(carManager.GetById(1003));
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(brandManager.GetById(car.BrandId).Data);
            }
        }

        private static void brandManagerTest()
        {
            //brandManager.Add(new Brand { Name = "Tesla", Model = "5" });
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName + " " + brand.Model);
            }
            //brandManager.Delete(brandManager.GetById(3));
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName + " " + brand.Model);
            }
        }

        private static void colorManagerTest()
        {
            //colorManager.Add(new Color {Name = "Turuncu"});
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName + " : " + color.ColorId.ToString());
            }
            //colorManager.Delete(colorManager.GetById(1002));
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void Test()
        {
            ShowCarsEf();
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            ShowCarsEfByColorId(1);
            Console.WriteLine("<><><><><><><><><><><><><><><><><><><><><><><><><><><><><>");
            
        }
        public static void ShowCarsEf()
        {
            Console.WriteLine("-------BUTUN ARACLAR------ -");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Arac Id: "+car.CarId + "-->" +
                                  "Marka: "+brandManager.GetById(car.BrandId).Data.BrandName + " " +
                                  "Model: "+brandManager.GetById(car.BrandId).Data.Model + " " +
                                  "Renk: "+colorManager.GetById(car.ColorId).Data.ColorName + " " +
                                  "Yil: "+car.ModelYear + " " +
                                  "Aciklama: "+car.Description);
            }
        }
        public static void ShowCarsEfByColorId(int i)
        {
            Console.WriteLine("ColorId= {0} OLAN ARACLAR", i);

            foreach (var car in carManager.GetCarsByColorId(i).Data)
            {
                Console.WriteLine("Arac Id: " + car.CarId + ":" +
                                  brandManager.GetById(car.BrandId).Data.BrandName + " " +
                                  brandManager.GetById(car.BrandId).Data.Model + " " +
                                  colorManager.GetById(car.ColorId).Data.ColorName + " " +
                                  car.ModelYear + " " +
                                  car.Description);
            }
        }
      
    }
}
