using System;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.Product;

namespace TradingPlatform.EntityContracts.ProductImage
{
    public class ProductImageReadDto
    {
        public byte[] ImageData { get; set; }
        public string GetImage()
        {
            var base64 = Convert.ToBase64String(ImageData);
            var image = string.Format("data:image/gif;base64,{0}", base64);
            return image;
        }
    }
}
