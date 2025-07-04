namespace qrMenu.Models
{
    public class MenuItem //bu sınıf bizim veri modelimiz
    {
        public int Id { get; set; } //otomatik artan id
        public string Name { get; set; } //yemek adı
        public string Description { get; set; } // açıklama
        public decimal Price { get; set; } // fiyat
        public string? ImageUrl { get; set; }  //görsel

        public string? Category { get; set; }     // Yiyecek / İçecek
        public string? SubCategory { get; set; }  // Tatlı, Ana Yemek, Soğuk İçecek vs.



        //CRUD işlemlerinde bu yapıyı kullanacağız
    }
}
