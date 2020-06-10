using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Lab1Data
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Model { get; set; } // модель консоли
        public string Brand { get; set; } // компания производитель
        public byte ModelId { get; set; } // серийный номер
        public string Type { get; set; } // тип консоли

        public BaseModelValidationResult Validate()

        {

            var validationResult = new BaseModelValidationResult();
            if (string.IsNullOrWhiteSpace(Model)) validationResult.Append($"Name cannot be empty");
            if (string.IsNullOrWhiteSpace(Brand)) validationResult.Append($"Surname cannot be empty");
            if (!(0 < ModelId && ModelId < 100)) validationResult.Append($"GroupIndex {ModelId} is out of range (0..100)");
            if (!string.IsNullOrEmpty(Model) && !char.IsUpper(Model.FirstOrDefault())) validationResult.Append($"Name {Model} should start from capital letter");
            if (!string.IsNullOrEmpty(Brand) && !char.IsUpper(Brand.FirstOrDefault())) validationResult.Append($"Surname {Brand} should start from capital letter");
            return validationResult;
        }

        public override string ToString()
        {
            return $"{Model} {Brand} from {Type}-{ModelId}";
        }
    }

}