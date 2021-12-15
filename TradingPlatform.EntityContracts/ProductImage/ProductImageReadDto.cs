using System;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.EntityContracts.ProductImage
{
    public class ProductImageReadDto
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public string GetImage()
        {
            if (Data == null)
            {
                return default;
            }  
            var base64 = Convert.ToBase64String(Data);
            var image = string.Format("data:image/gif;base64,{0}", base64);
            return image;
        }
    }
}